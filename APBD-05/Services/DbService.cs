using APBD_05.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace APBD_05.Services
{
    public class DbService : IDbService
    {
        private IConfiguration _configuration;
        public DbService(IConfiguration configuration)
        {https://stg-storefront.lova.care/_next/image?url=%2F_next%2Fstatic%2Fmedia%2Fcoming-soon-up-lg.a0c04396.webp&w=1920&q=75
            _configuration = configuration;
        }
        public async Task<int> AddProductToWarehouseAsync(Product product)
        {
            int countProducts_Warehouses_Orders = 0;

            using var con = new SqlConnection(_configuration.GetConnectionString("ProductionDb"));
            using var com = new SqlCommand("SELECT COUNT(*) FROM PRODUCT WHERE IDPRODUCT = @IdProduct", con);
            com.Parameters.AddWithValue("@IdProduct", product.IdProduct);
            com.Parameters.AddWithValue("@IdWarehouse", product.IdWarehouse);

            await con.OpenAsync();
            DbTransaction tran = await con.BeginTransactionAsync();
            com.Transaction = (SqlTransaction)tran;

            using(var reader = await com.ExecuteReaderAsync())
            {
                if (reader.Read())
                {
                    countProducts_Warehouses_Orders = reader.GetInt32(0);
                }
            }

            if (countProducts_Warehouses_Orders > 0)
            {
                com.CommandText = "SELECT COUNT(*) FROM WAREHOUSE WHERE IDWAREHOUSE = @IdWarehouse";
                using (var reader = await com.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        countProducts_Warehouses_Orders = reader.GetInt32(0);
                    }
                }
            }









            return countProducts;
        }
    }
}

/*
    cmd.Parameters.AddWithValue("@IdProduct", product.IdProduct);
    cmd.Parameters.AddWithValue("@IdWarehouse", product.IdWarehouse);
    cmd.Parameters.AddWithValue("@Amount", product.Amount);
    cmd.Parameters.AddWithValue("@CreatedAt", product.CreatedAt);

    cmd.CommandText = "insert into Animal(Name, Description, Category, Area) values(@name, @description, @category, @area)";
*/