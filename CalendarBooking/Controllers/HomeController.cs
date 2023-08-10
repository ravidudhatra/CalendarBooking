using CalendarBooking.Data;
using CalendarBooking.Data.Model;
using CalendarBooking.Data.Repository;
using CalendarBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
namespace CalendarBooking.Controllers
{
    public class HomeController : Controller
    {

        private readonly IBookingRepository _bookingRepository;


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
            IBookingRepository bookingRepository)
        {
            _logger = logger;
            _bookingRepository = bookingRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GetCalendarData()
        {

            List<AvailibilityDto> data = new List<AvailibilityDto>();

            //Statically create list and add data  
            AvailibilityDto infoObj1 = new AvailibilityDto();
            infoObj1.Id = 1;
            infoObj1.Title = "I am available";
            infoObj1.Desc = "Description 1";
            infoObj1.Start_Date = "2020-08-16 22:37:22.467";
            infoObj1.End_Date = "2020-08-16 23:30:22.467";
            data.Add(infoObj1);

            AvailibilityDto infoObj2 = new AvailibilityDto();
            infoObj2.Id = 2;
            infoObj2.Title = "Available";
            infoObj2.Desc = "Description 1";
            infoObj2.Start_Date = "2020-08-17 10:00:22.467";
            infoObj2.End_Date = "2020-08-17 11:00:22.467";
            data.Add(infoObj2);


            AvailibilityDto infoObj3 = new AvailibilityDto();
            infoObj3.Id = 3;
            infoObj3.Title = "Meeting";
            infoObj3.Desc = "Description 1";
            infoObj3.Start_Date = "2020-08-18 07:30:22.467";
            infoObj3.End_Date = "2020-08-18 08:00:22.467";
            data.Add(infoObj3);

            return new JsonResult(data);

        }

        public async Task<JsonResult> GetBookings()
        {
            var result = await _bookingRepository.GettAllBooking();
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<JsonResult> SaveBooking(Booking e)
        {
            var status = false;
            try
            {
                await _bookingRepository.SaveBooking(e);
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }

            return new JsonResult(status);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteEvent(int bookingId)
        {
            bool status = false;
            try
            {
                status = await _bookingRepository.RemoveBooking(bookingId);
            }
            catch
            {
                status = false;
            }
            return new JsonResult(status);
        }
    }
}