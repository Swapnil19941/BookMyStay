using BookMyStay.Api.Services;
using BookMyStay.Api.Services.Abstractions;
using BookMyStay.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookMyStay.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : Controller
    {
        #region Private Variables
        //loggger get from di container no need to register in program.cd
        private ILogger<HotelsController> _logger;
        private ISingletonOperation _singletonOperation;
        private IScopedOperation _scopedOperation;
        private ITransientOperation _transientOperation;
        private MyFirstService _firstService { get; set; }

        #endregion Private Variables

        #region Constructor
        public HotelsController(ILogger<HotelsController> logger, MyFirstService myFirstService,ISingletonOperation singletonOperation, IScopedOperation scopedOperation, ITransientOperation transientOperation)
        {
            _firstService = myFirstService;
            _singletonOperation = singletonOperation;
            _scopedOperation = scopedOperation;
            _transientOperation = transientOperation;
            _logger = logger;
        }
        #endregion Constructor
        [HttpGet]
        public IActionResult GetHotels()
        {
            _logger.LogInformation($"GUID of singleton: {_singletonOperation.Guid}");
            _logger.LogInformation($"GUID of transient: {_transientOperation.Guid}");
            _logger.LogInformation($"GUID of scoped: {_scopedOperation.Guid}");

            var hotels = _firstService.GetAllHotels();
            return Ok(hotels);
        }

        [HttpGet]
        [Route("{id}", Name = "GetHotelById")]
        public IActionResult GetHotelById(int id)
        {

            var hotels = _firstService.GetAllHotels();
            var hotel = hotels.FirstOrDefault(h => h.HotelId == id);

            if(hotel == null)
                return NotFound();

            return Ok(hotel);
        }

        [HttpPost]
        public IActionResult CreateHotel([FromBody] Hotel hotel)
        {
            var hotels = _firstService.GetAllHotels();
            hotels.Add(hotel);
            return CreatedAtRoute(nameof(GetHotelById), new { id = hotel.HotelId }, hotel);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateHotel([FromBody] Hotel updated, int id)
        {
            var hotels = _firstService.GetAllHotels();
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
            var hotels = _firstService.GetAllHotels();
            var toDelete = hotels.FirstOrDefault(h => h.HotelId == id);

            if(toDelete == null)
                return NotFound("No Hotel found to delete.");

            hotels.Remove(toDelete);
            return NoContent();
        }

    }
}
