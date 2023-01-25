using APBD_07.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBD_07.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTrips()
        {
            var context = new S17263Context();
            var trips = context.Trips;
            return Ok(trips);
        }
    }
}