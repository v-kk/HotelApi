using Hotel.API.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Hotel.API.Services
{
    public class HotelsService
    {
        private readonly List<Hotels> _hotels;
        private readonly ILogger<HotelsService> _logger;

        public HotelsService(IConfiguration configuration, ILogger<HotelsService> logger)
        {

            _logger = logger;

            try
            {
                var jsonData = File.ReadAllText(configuration["DataFilePath"]);
                _hotels = JsonSerializer.Deserialize<List<Hotels>>(jsonData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The hotels.json file was not found." );

                throw new Exception("Failed to load hotels data.Please check the configuration.");
            }
        }

        public List<Hotels> GetAllHotels()
        {
            return _hotels;
        }

        public Hotels GetHotelById(int id)
        {
            return _hotels.Find(hotel => hotel.Id == id);
        }
    }
}
