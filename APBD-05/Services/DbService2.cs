using APBD_05.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace APBD_05.Services
{
    public class DbService2 : IDbService2
    {
        private IConfiguration _configuration;
        public DbService2(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task AddProductToWarehouseAsync(Product product)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
            {
                SqlCommand cmd = new SqlCommand("AddProductToWarehouse", con);
                cmd.CommandType = CommandType.StoredProcedure;
                await con.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }
    }
}
