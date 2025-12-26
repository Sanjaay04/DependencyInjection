using DependencyInjection.Interface;
using DependencyInjection.Model;
using Microsoft.Data.SqlClient;

namespace DependencyInjection.Service
{
    public class ProductService : Iproductservice
    {
        private readonly string _cong;

        public ProductService(IConfiguration configuration)
        {
            _cong = configuration.GetConnectionString("DefaultConnection");
        }

        public List<product> Getallproducts()
        {
            var products = new List<product>();

            using (var connection = new SqlConnection(_cong))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT Id, Name, Price FROM Products", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new product
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"])
                            });
                        }
                    }
                }
            }

            return products;
        }

    }
}
