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
            int Products = 0;
            int Warehouses = 0;
            int IdOrder = 0;
            int WarehouseWithThisOrder = -1;
            int rowsAffected = 0;

            using var con = new SqlConnection(_configuration.GetConnectionString("ProductionDb"));
            using var com = new SqlCommand("SELECT COUNT(*) FROM PRODUCT WHERE IDPRODUCT = @IdProduct", con);
            com.Parameters.AddWithValue("@IdProduct", product.IdProduct);
            com.Parameters.AddWithValue("@IdWarehouse", product.IdWarehouse);
            com.Parameters.AddWithValue("@Amount", product.Amount);
            com.Parameters.AddWithValue("@CreatedAt", product.CreatedAt);
            com.Parameters.AddWithValue("@Price", product.Price);

            await con.OpenAsync();
            DbTransaction tran = await con.BeginTransactionAsync();
            com.Transaction = (SqlTransaction)tran;

            using(var reader = await com.ExecuteReaderAsync())
            {
                if (reader.Read())
                {
                    Products = reader.GetInt32(0);
                }
            }

            if (Products > 0)
            {
                com.CommandText = "SELECT COUNT(*) FROM WAREHOUSE WHERE IDWAREHOUSE = @IdWarehouse";
                using (var reader = await com.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        Warehouses = reader.GetInt32(0);
                    }
                }
            }

            if (Warehouses > 0 & product.Amount > 0)
            {
                com.CommandText = "SELECT IdOrder FROM \"ORDER\" WHERE IDPRODUCT = @IdProduct AND AMOUNT = @Amount AND CREATEDAT < @CreatedAt AND FULFILLEDAT IS NULL;";
                using (var reader = await com.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        IdOrder = reader.GetInt32(0);
                        com.Parameters.AddWithValue("@IdOrder", IdOrder);
                    }
                }
            }

            if (IdOrder > 0)
            {
                com.CommandText = "SELECT COUNT(*) FROM PRODUCT_WAREHOUSE JOIN \"ORDER\" ON PRODUCT_WAREHOUSE.IDORDER = \"ORDER\".IDORDER WHERE PRODUCT_WAREHOUSE.IDORDER = @IdOrder";
                using (var reader = await com.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        WarehouseWithThisOrder = reader.GetInt32(0);
                    }
                }
            }

            if (WarehouseWithThisOrder == 0)
            {
                com.CommandText = "UPDATE \"ORDER\" SET FULFILLEDAT = @CreatedAt WHERE IDORDER = @IdOrder";
                rowsAffected = await com.ExecuteNonQueryAsync();
                com.CommandText = "INSERT INTO PRODUCT_WAREHOUSE VALUES  (@IdWarehouse, @IdProduct, @IdOrder, @Amount, @Price, @CreatedAt)";
                rowsAffected = await com.ExecuteNonQueryAsync();
            }
            return rowsAffected;
        }
    }
}