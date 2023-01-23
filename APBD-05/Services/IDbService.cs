using APBD_05.Models;
using System.Threading.Tasks;

namespace APBD_05.Services
{
    public interface IDbService
    {
        Task<int> AddProductToWarehouseAsync(Product product);
    }
}
