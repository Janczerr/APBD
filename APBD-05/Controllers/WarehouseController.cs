using APBD_05.Models;
using APBD_05.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace APBD_05.Controllers
{
    [ApiController]
    [Route("api/warehouses")]
    public class WarehouseController : ControllerBase
    {
        private IDbService _dbService;
        public WarehouseController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToWarehouse(Product product)
        {
            return Ok(await _dbService.AddProductToWarehouseAsync(product));
        }
    }
}
