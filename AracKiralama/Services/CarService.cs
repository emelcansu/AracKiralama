
using System.Net.Http.Json;
using AracKiralama.Models;

namespace AracKiralama.Services
{
    public class CarService
    {
        private readonly HttpClient _httpClient;

        public CarService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Car>> GetCarsAsync()
        {
            var cars = await _httpClient.GetFromJsonAsync<List<Car>>("cars.json");

            return cars ?? new List<Car>();
        }

        public async Task<Car?> GetCarByIdAsync(string id)
        {
            var cars = await GetCarsAsync();

            return cars.FirstOrDefault(car => car.Id == id);
        }
    }
}
