using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorApp.Data;

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
            _address = address + BaseAddress;
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

        //TODO save userIDs
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
            var response = await new HttpClient().GetAsync(_address + $"/{chatId}" + "/messages" + $"?user_id={userId}" + $"&?text={text}");
            
            return response;
        }

        public async Task<string> GetMessagesByChatId(string chatId, int limit = 1000, string from = null!)
        {
            return await new HttpClient().GetStringAsync(_address + $"/{chatId}" + "/messages" +
                                                         $"?limit={limit}"+ $"&?from={from}");
        }

        public async Task<List<ChatMessage>> GetMessagesList(string chatId, string userName)
        {
            string? ans = GetMessagesByChatId(chatId).ToString();

            Console.WriteLine(ans);

            if (ans == null)
            {
                return new List<ChatMessage>();
            }
            
            /*
            var messagesJson = await new HttpClient().GetStringAsync(_address + BaseAddress + $"?chat_id={_chatId}" + $"limit=1000");

            ChatGetMessagesResponse? messages = JsonSerializer.Deserialize<ChatGetMessagesResponse>(messagesJson);

            List<ChatMessage> chatMessages = new List<ChatMessage>();

            if (messages != null)
            {
                foreach (Message message in messages.messages)
                {
                    chatMessages.Add(new ChatMessage(message.messageId, message.text, userName == message.messageId));
                }
            }

            return chatMessages;
            */

            return new List<ChatMessage>();
        }
    }
}