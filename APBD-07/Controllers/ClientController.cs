using APBD_07.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBD_07.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController : ControllerBase
    {
        [HttpDelete("{IdClient}")]
        public async Task<IActionResult> DeleteClient(int IdClient)
        {
            var context = new S17263Context();
            var client = context.Clients.Where(e => (e.IdClient == IdClient) & (e.ClientTrips.Count() == 0)).First();
            context.Clients.Remove(client);
            context.SaveChangesAsync();
            return Ok();
        }
    }
}
