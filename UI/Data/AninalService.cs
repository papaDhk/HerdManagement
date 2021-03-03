using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Application.Data.DTO.Reproduction;
using Application.Services;
using HerdManagement.Domain.Reproduction.Entities;

namespace UI.Data
{
    public class AnimalService
    {
        private readonly HttpClient _httpClient;

        public AnimalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Animal>> GetAnimalsByHerdId(int herdId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Animal>>($"Animals?herdId={herdId}");
        }
        
        public async Task<IEnumerable<Female>> GetFemalesByHerdId(int herdId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Female>>($"Animals/GetFemalesByHerdId?herdId={herdId}");
        }
        
        public async Task<IEnumerable<Male>> GetMalesByHerdId(int herdId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Male>>($"Animals/GetMalesByHerdId?herdId={herdId}");
        }
        
        public async Task<AddNewAnimalResult> AddNewAnimal(AnimalDTO animalDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Animals/AddNewAnimal",animalDto);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<AddNewAnimalResult>();
            }

            return null;
        }
        
        public async Task<UpdateAnimalResult> UpdateAnimal(Animal animal, int motherId, int fatherId)
        {
            var response = await _httpClient.PutAsJsonAsync($"Animals/UpdateAnimal?motherId={motherId}&fatherId={fatherId}",animal);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<UpdateAnimalResult>();
            }

            return null;
        }
    }
}