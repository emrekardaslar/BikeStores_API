using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text;
using BikeStores.Core.Entities;
using BikeStores.Core.Interfaces;

namespace BikeStores.Infrastructure.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository(IConfiguration configuration, ILogger<CustomerRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new { customer_id = id };

                _logger.LogInformation($"Executing stored procedure get_customer_by_id with parameter: {id}");

                var customers = await connection.QueryAsync(
                    "get_customer_by_id",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                var customer = customers.Select(row => new Customer
                {
                    Id = row.customer_id,
                    Name = row.first_name,
                    Email = row.email
                }).FirstOrDefault();

                if (customer == null)
                {
                    _logger.LogError($"No customer found with id: {id}");
                }

                return customer;
            }
        }

        public async Task<IEnumerable<Order>> GetCustomerOrdersByEmailAsync(string email)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var parameters = new { customer_email = email };

                    _logger.LogInformation($"Executing stored procedure get_customer_orders_by_email with parameter: {email}");

                    var orders = await connection.QueryAsync<dynamic>(
                        "get_customer_orders_by_email",
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return orders.Select(row =>
                    {
                        return new Order
                        {
                            OrderId = row.order_id,
                            OrderStatus = row.order_status.ToString(), // Ensure this is treated as a string
                            OrderDate = row.order_date,
                            RequiredDate = row.required_date,
                            ShippedDate = row.shipped_date == null ? (DateTime?)null : row.shipped_date, // Handle NULL shipped_date
                            StoreName = row.store_name is byte[]? Encoding.UTF8.GetString(row.store_name) : row.store_name.ToString(), // Handle byte[] to string conversion
                            StaffFirstName = row.staff_first_name is byte[]? Encoding.UTF8.GetString(row.staff_first_name) : row.staff_first_name.ToString(), // Handle byte[] to string conversion
                            StaffLastName = row.staff_last_name is byte[]? Encoding.UTF8.GetString(row.staff_last_name) : row.staff_last_name.ToString(), // Handle byte[] to string conversion
                            TotalOrderValue = row.total_order_value
                        };
                    }).ToList();

                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "An error occurred while executing the stored procedure.");
                throw;
            }
        }

    }
}
