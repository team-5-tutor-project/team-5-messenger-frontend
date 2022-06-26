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

        public async Task<string> GetUserByToken(string? token)
        {
            var response = await new HttpClient().GetStringAsync(_address + BaseAddress + "/authorization" + $"?token={token}");

            return response;
        }

        public async Task<string> GetClientByToken(string? token)
        {
            var response = await new HttpClient().GetStringAsync(_address + BaseAddress + "/clients" + $"?token={token}");
            
            return response;
        }

        public async Task<string> GetTutorByToken(string? token)
        {
            var response = await new HttpClient().GetStringAsync(_address + BaseAddress + "/tutors" + $"?token={token}");
            
            return response;
        }
    }
}