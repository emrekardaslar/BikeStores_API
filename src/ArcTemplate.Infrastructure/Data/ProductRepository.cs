using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using ArcTemplate.Core.Entities;
using ArcTemplate.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ArcTemplate.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(IConfiguration configuration, ILogger<ProductRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
        }

        public Product GetProductById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new { ProductId = id };

                _logger.LogInformation($"Executing stored procedure get_product_by_id with parameter: {id}");

                var product = connection.Query(
                    "get_product_by_id",
                    parameters,
                    commandType: CommandType.StoredProcedure
                ).Select(row => new Product
                {
                    Id = row.product_id,
                    Name = row.product_name,
                    Price = row.list_price
                }).FirstOrDefault();

                if (product == null)
                {
                    _logger.LogWarning($"No product found with id: {id}");
                }

                return product;
            }
        }
    }
}
