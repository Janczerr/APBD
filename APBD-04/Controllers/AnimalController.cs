using APBD_04.Models;
using APBD_04.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_04.Controllers
{
    [ApiController]
    [Route("api/animals")]
    public class AnimalController : ControllerBase
    {
        private IDbService _dbService;

        public AnimalController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetAnimals()
        {
            return Ok(_dbService.GetAnimals());
        }

        [HttpGet("{idAnimal}")]
        public IActionResult GetAnimal(int idAnimal)
        {
            return Ok(_dbService.GetAnimal(idAnimal));
        }

        [HttpPost]
        public IActionResult PostAnimal(Animal animal)
        {
            return Ok(_dbService.AddAnimal(animal));
        }

        [HttpDelete("{idAnimal}")]
        public IActionResult RemoveAnimal(int idAnimal)
        {
            return Ok(_dbService.RemoveAnimal(idAnimal));
        }

        [HttpPut("{idAnimal}")]
        public IActionResult UpdateAnimal(Animal animal, int idAnimal)
        {
            return Ok(_dbService.UpdateAnimal(animal, idAnimal));
        }
    }
}
