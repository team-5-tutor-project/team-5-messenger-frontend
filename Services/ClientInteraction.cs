using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorApp.Data.ClientDtos;

namespace BlazorApp.Services
{
    public class ClientInteraction
    {
        private readonly string _address;

        private const string BaseAddress = "/api";

        public ClientInteraction(string address)
        {
            _address = address;
        }

        public async Task<UserByTokenDto?> GetUserByToken(string? token)
        {
            //var response = await new HttpClient().GetStringAsync(_address + BaseAddress + "/authorization" + $"?token={token}");
            var response = await new HttpClient().GetStringAsync("http://localhost:4000/api/authorization?token=99996086-1c88-4638-b918-d60833a40fe8");
            
            UserByTokenDto? user = JsonSerializer.Deserialize<UserByTokenDto>(response ?? throw new InvalidOperationException());

            return user;
        }

        public async Task<ClientDto?> GetClientByToken(string? token)
        {
            var response = await new HttpClient().GetStringAsync(_address + BaseAddress + "/clients" + $"?token={token}");

            ClientDto? client = JsonSerializer.Deserialize<ClientDto>(response);

            return client;
        }

        public async Task<TutorDto?> GetTutorByToken(string? token)
        {
            var response = await new HttpClient().GetStringAsync(_address + BaseAddress + "/tutors" + $"?token={token}");

            TutorDto? tutor = JsonSerializer.Deserialize<TutorDto>(response);

            return tutor;
        }
    }
}