using APBD_07.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;

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
            var trips = context.Trips.OrderBy(e => e.DateFrom);
            return Ok(trips);
        }

        [HttpPost("{IdTrip}/clients")]
        public async Task<IActionResult> AddClient(ClientTripDTO clientTripDTO)
        {
            var context = new S17263Context();
            var clients = context.Clients.ToList();

            var ClientDto = new ClientTripDTO();
            return Ok();
            
        }

    }
}