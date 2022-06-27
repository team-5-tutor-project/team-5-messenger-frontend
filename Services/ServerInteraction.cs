using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorApp.Data;
using BlazorApp.Data.ClientDtos;

namespace BlazorApp.Services
{
    public class ServerInteraction
    {
        private readonly string _address;

        private const string BaseAddress = "/v1/chats";

        private string? _chatId;

        private string _userIdFirst;

        private string _userIdSecond;

        public ServerInteraction(string address)
        {
            _address = address;
        }

        public ServerInteraction(string address, string chadId)
            : this(address)
        {
            _chatId = chadId;
        }

        public async Task<HttpResponseMessage> CreateChatWithName(string chatName)
        {
            var jsonChat = JsonSerializer.Serialize<CreateChatDto>(new CreateChatDto(chatName));
            var data = new StringContent(jsonChat, Encoding.UTF8, "application/json");

            var response = await new HttpClient().PostAsync(_address, data);

            return response;
        }
        
        public async Task<HttpResponseMessage> CreateChatWithNameAnd2Users(string chatName, string userNameFirst,
            string userNameSecond)
        {
            var jsonChatWithUsers =
                JsonSerializer.Serialize<CreateChatWithTwoUsersDto>(
                    new CreateChatWithTwoUsersDto(chatName, userNameFirst, userNameSecond));

            var data = new StringContent(jsonChatWithUsers, Encoding.UTF8, "application/json");

            var response = await new HttpClient().PostAsync(_address + "/default", data);

            return response;
        }

        public async Task<HttpResponseMessage> JoinUserToChat(string chatId, string userName)
        {
            var jsonJoinUser = JsonSerializer.Serialize<UserNameDto>(new UserNameDto(userName));
            var data = new StringContent(jsonJoinUser, Encoding.UTF8, "application/json");

            var response = await new HttpClient().PostAsync(_address + $"/{chatId}" + "/users", data);

            return response;
        }

        public async Task<HttpResponseMessage> SendMessage(string chatId, string userId, string text)
        {
            var parameters = new Dictionary<string, string>
            {
                {"user_id", userId},
                {"text", text}
            };

            var content = new FormUrlEncodedContent(parameters);

            var message = await new HttpClient().PostAsync(_address + BaseAddress + $"/{chatId}" + "/messages", content);

            return message;
        }

        public async Task<string> GetMessagesByChatId(string chatId, int limit = 1000, string? from = null)
        {
            try
            {
                if (from == null) from = "";

                return await new HttpClient().GetStringAsync(_address + BaseAddress + $"/{chatId}" + "/messages" +
                                                             $"?limit={limit}" + $"&?from={from}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<ChatMessage>> GetMessagesList(string chatId, string userId, string userName)
        {
            string? ans = await GetMessagesByChatId(chatId);

            if (ans == null)
            {
                return new List<ChatMessage>();
            }

            ChatGetMessagesResponse? messages = JsonSerializer.Deserialize<ChatGetMessagesResponse>(ans);

            List<ChatMessage> chatMessages = new List<ChatMessage>();

            string? secondUserName = null;

            if (messages != null)
            {
                foreach (Message message in messages.messages)
                {
                    if (message.id != userId)
                    {
                        if (secondUserName == null)
                        {
                            try
                            {
                                var clientInter = new ClientInteraction("https://tutor-project-test.herokuapp.com");
                                string? nameResponse = await clientInter.GetClientUsernameByUserId(message.id);

                                secondUserName = JsonSerializer.Deserialize<NameDto>(nameResponse)?.name;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        
                        if (secondUserName == null)
                        {
                            try
                            {
                                var clientInter = new ClientInteraction("https://tutor-project-test.herokuapp.com");
                                string? nameResponse = await clientInter.GetTutorUsernameByUserId(message.id);

                                secondUserName = JsonSerializer.Deserialize<NameDto>(nameResponse)?.name;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
            
                        chatMessages.Add(new ChatMessage(secondUserName, message.text, userId == message.id));
                    }
                    else
                    {
                        chatMessages.Add(new ChatMessage(userName, message.text, userId == message.id));
                    }
                }
            }

            return chatMessages;
        }
    }
}