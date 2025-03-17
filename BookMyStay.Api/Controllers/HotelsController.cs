using BookMyStay.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMyStay.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : Controller
    {
        #region Private Variables
        private DataSource _dataSource { get; set; }

        #endregion Private Variables

        #region Constructor
        public HotelsController(DataSource dataSource) {
            _dataSource = dataSource;
        }
        #endregion Constructor
        [HttpGet]
        public IActionResult GetHotels()
        {
            var hotels = _dataSource.hotels;
            return Ok(hotels);
        }

        [HttpGet]
        [Route("{id}", Name = "GetHotelById")]
        public IActionResult GetHotelById(int id)
        {
            var hotels = _dataSource.hotels;
            var hotel = hotels.FirstOrDefault(h => h.HotelId == id);

            if(hotel == null)
                return NotFound();

            return Ok(hotel);
        }

        [HttpPost]
        public IActionResult CreateHotel([FromBody] Hotel hotel)
        {
            var hotels = _dataSource.hotels;
            hotels.Add(hotel);
            return CreatedAtRoute(nameof(GetHotelById), new { id = hotel.HotelId }, hotel);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateHotel([FromBody] Hotel updated, int id)
        {
            var hotels = _dataSource.hotels;
            var old = hotels.FirstOrDefault(h => h.HotelId == id);

            if (old == null) 
                return NotFound("No Hotel found to update.");

            hotels.Remove(old);
            hotels.Add(updated);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteHotel(int id)
        {
            var hotels = _dataSource.hotels;
            var toDelete = hotels.FirstOrDefault(h => h.HotelId == id);

            if(toDelete == null)
                return NotFound("No Hotel found to delete.");

            hotels.Remove(toDelete);
            return NoContent();
        }

    }
}
