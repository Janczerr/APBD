using APBD_04.Models;
using System.Collections.Generic;

namespace APBD_04.Services
{
    public interface IDbService
    {
        ICollection<Animal> GetAnimals();
        Animal GetAnimal(int id);
        public int AddAnimal(Animal animal);
        public int RemoveAnimal(int id);
        public int UpdateAnimal(Animal animal, int id);
    }
}
