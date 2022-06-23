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

        private const string BaseAddress = "/api/authorization";

        public ClientInteraction(string address)
        {
            _address = address;
        }

        public async Task<UserByTokenDto?> GetUserByToken(string? token)
        {
            var response = await new HttpClient().GetStringAsync(_address + BaseAddress + $"?token={token}");

            UserByTokenDto? user = JsonSerializer.Deserialize<UserByTokenDto>(response ?? throw new InvalidOperationException());

            return user;
        }
    }
}