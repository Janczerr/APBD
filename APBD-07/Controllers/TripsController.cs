using APBD_07.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBD_07.Controllers
{
    [ApiController]
    [Route("api/trips")]
    public class TripsController : ControllerBase
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