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
            //var response = await new HttpClient().GetStringAsync("http://localhost:4000/api/authorization?token=8535b815-5b88-4575-bdcf-003280629e87");

            return response;
        }

        public async Task<string> GetClientByToken(string? token)
        {
            var response = await new HttpClient().GetStringAsync(_address + BaseAddress + "/clients" + $"?token={token}");
            //var response = await new HttpClient().GetStringAsync("http://localhost:4000/api/clients?token=8535b815-5b88-4575-bdcf-003280629e87");
            
            return response;
        }

        public async Task<string> GetTutorByToken(string? token)
        {
            var response = await new HttpClient().GetStringAsync(_address + BaseAddress + "/tutors" + $"?token={token}");
            //var response = await new HttpClient().GetStringAsync("http://localhost:4000/api/tutors?token=8535b815-5b88-4575-bdcf-003280629e87");

            return response;
        }
    }
}