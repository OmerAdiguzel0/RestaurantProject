using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLayer.Abstract;
using Restaurant.DTOLayer.BookingDTO;
using Restaurant.EntityLayer.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDTO createBookingDTO)
        {
            Booking booking = new Booking()
            {
                Mail = createBookingDTO.Mail,
                Date = createBookingDTO.Date,
                Name = createBookingDTO.Name,
                PersonCount = createBookingDTO.PersonCount,
                Phone = createBookingDTO.Phone
            };
            _bookingService.TAdd(booking);
            return Ok("Rezervasyon yapıldı.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("Rezervasyon silindi.");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDTO updateBookingDTO)
        {
            Booking booking = new Booking()
            {
                BookingId = updateBookingDTO.BookingId,
                Mail = updateBookingDTO.Mail,
                Date = updateBookingDTO.Date,
                Name = updateBookingDTO.Name,
                PersonCount = updateBookingDTO.PersonCount,
                Phone = updateBookingDTO.Phone
            };
            _bookingService.TUpdate(booking);
            return Ok("Rezervasyon güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            return Ok(value);
        }
    }
}
