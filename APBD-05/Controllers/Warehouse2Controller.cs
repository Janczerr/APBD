using Microsoft.AspNetCore.Mvc;
using APBD_05.Services;
using System.Threading.Tasks;
using APBD_05.Models;

namespace APBD_05.Controllers
{
    [ApiController]
    [Route("api/warehouses2")]
    public class Warehouse2Controller : ControllerBase
    {
        private IDbService2 _dbService;
        public Warehouse2Controller(IDbService2 dbService)
        {
            _dbService = dbService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToWarehouse(Product product)
        {
            await _dbService.AddProductToWarehouseAsync(product);
            return Ok();
        }

    }
}
