using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using BikeStores.Core.Entities;
using BikeStores.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BikeStores.Infrastructure.Data
{
    public class BrandRepository : IBrandRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<BrandRepository> _logger;

        public BrandRepository(IConfiguration configuration, ILogger<BrandRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
        }

        public Brand GetBrandById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new { BrandId = id };

                _logger.LogInformation($"Executing stored procedure get_brand_by_id with parameter: {id}");

                var brand = connection.Query(
                    "get_brand_by_id",
                    parameters,
                    commandType: CommandType.StoredProcedure
                ).Select(row => new Brand
                {
                    Id = row.brand_id,
                    Name = row.brand_name,
                }).FirstOrDefault();

                if (brand == null)
                {
                    _logger.LogWarning($"No brand found with id: {id}");
                }

                return brand;
            }
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                _logger.LogInformation("Executing stored procedure get_all_brands");

                var brands = connection.Query(
                    "get_all_brands",
                    commandType: CommandType.StoredProcedure
                ).Select(row => new Brand
                {
                    Id = row.brand_id,
                    Name = row.brand_name
                }).ToList();

                return brands;
            }
        }

    }
}
