using System.Net.Http;

namespace UI.Data
{
    public class SpecieBreedDataService
    {
        private readonly HttpClient _httpClient;

        public SpecieBreedDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        
    }
}