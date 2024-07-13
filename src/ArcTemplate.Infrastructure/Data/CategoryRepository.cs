using ArcTemplate.Core.Entities;
using ArcTemplate.Core.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace ArcTemplate.Infrastructure.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<CategoryRepository> _logger;

        public CategoryRepository(IConfiguration configuration, ILogger<CategoryRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
        }

        public IEnumerable<Product> GetCategoryProducts(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new { CategoryName = name };

                _logger.LogInformation($"Executing stored procedure get_products_by_category_name with parameter: {name}");

                var products = connection.Query<dynamic>(
                    "get_products_by_category_name",
                    parameters,
                    commandType: CommandType.StoredProcedure
                ).Select(row =>
                {
                    _logger.LogInformation($"Row data: product_name={row.product_name}, list_price={row.list_price}, brand_name={row.brand_name}");

                    return new Product
                    {
                        Name = row.product_name,
                        Price = row.list_price
                    };
                });

                return products;
            }
        }
    }
}
