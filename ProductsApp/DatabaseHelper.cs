using System.Data;
using System.Data.SqlClient;

namespace ProductsApp
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(@"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Products' AND xtype='U')
                    CREATE TABLE Products (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        Name NVARCHAR(100) NOT NULL,
                        Price DECIMAL(18,2) NOT NULL,
                        Quantity INT NOT NULL
                    )", connection);
                command.ExecuteNonQuery();
            }
        }

        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT Id, Name, Price, Quantity FROM Products", connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Price = (decimal)reader["Price"],
                        Quantity = (int)reader["Quantity"]
                    });
                }
            }
            return products;
        }

        public void AddProduct(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(@"
                    INSERT INTO Products (Name, Price, Quantity) 
                    VALUES (@Name, @Price, @Quantity)", connection);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Quantity", product.Quantity);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateProduct(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(@"
                    UPDATE Products 
                    SET Name = @Name, Price = @Price, Quantity = @Quantity 
                    WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", product.Id);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Quantity", product.Quantity);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Products WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
