using Hotel.API.Models;
using Hotel.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    //https://localhost:portnumber/api/hotels
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {

        private readonly HotelsService _hotelsService;

        public HotelsController(HotelsService hotelsService)
        {
            _hotelsService = hotelsService;
        }

        /// <summary>
        /// Retrieves all hotels.
        /// </summary>
        /// <returns>All Hotels</returns>
   
        //GET: https://localhost:portnumber/api/hotels
        [HttpGet]
        public ActionResult<List<Hotels>> GetAllHotels()
        {
            try
            {
                var hotels = _hotelsService.GetAllHotels();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occured while fetching hotel details.", Details = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves details of a specific hotel by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Hotel with the Id if exists.</returns>

        //GET: https://localhost:portnumber/api/hotels/{id}
        [HttpGet("{id}")]
        public ActionResult<Hotels> GetHotelsById(string id)
        {
            if(!int.TryParse(id, out var hotelId))
            {
                return BadRequest(new { Message = "The ID is invalid. Please Enter a numeric value." });
            }

            var hotel = _hotelsService.GetHotelById(hotelId);
            if(hotel == null)
            {
                return  NotFound(new {Message = $"Hotel with ID {hotelId} not found."});
            }

            return Ok(hotel);
        }
    }
}