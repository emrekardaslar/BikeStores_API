using System.Data;
using Dapper;
using ArcTemplate.Core.Entities;
using ArcTemplate.Core.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text;

namespace ArcTemplate.Infrastructure.Data
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

        public Customer GetCustomerById(int id)
        {
            // Mock data
            return new Customer { Id = id, Name = "Example Customer" };
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
