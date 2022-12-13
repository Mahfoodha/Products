using System;
using Microsoft.Data.Sqlite;
using Products.Models;

namespace Products.Repository
{
	public class ProductRepository : Repository
	{
        
        CategoryRepository categoryRepository;

        public ProductRepository() : base()
        {
            categoryRepository = new CategoryRepository();
        }
		public Product? GetProductById(int id)
		{

            var command = connection.CreateCommand();
            command.CommandText = @"select * from categories where id= $id";
            command.Parameters.AddWithValue("$id", id);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                    return convertToProduct(reader);
            }
            return null;
		}

        

        public List<Product> getAll()
        {
            List<Product> products =  new List<Product>();
            var command = connection.CreateCommand();
            command.CommandText = @"select * from products";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                    products.Add(convertToProduct(reader));
            }
            return products;
        }
        public bool Insert(Product product)
        {
            var command = connection.CreateCommand();
            command.CommandText = @"insert into products(name,description,price,category)
            values($name,$description,$price,$category)";
            command.Parameters.AddWithValue("$name", product.name);
            command.Parameters.AddWithValue("$description", product.description);
            command.Parameters.AddWithValue("$price", product.price);
            command.Parameters.AddWithValue("$category", product.category.id);
            return command.ExecuteNonQuery() > 0;
           
        }
        public bool Delete(int id)
        {
            var command = connection.CreateCommand();
            command.CommandText = @"delete products where id= $id";
            command.Parameters.AddWithValue("$id", id);
            return command.ExecuteNonQuery() > 0;

        }
        public bool Update(Product product)
        {
            var command = connection.CreateCommand();
            command.CommandText = @"update products set name=$name,description=$description,
            price=$price,category=$category where id= $id";
            command.Parameters.AddWithValue("$name", product.name);
            command.Parameters.AddWithValue("$description", product.description);
            command.Parameters.AddWithValue("$price", product.price);
            command.Parameters.AddWithValue("$category", product.category.id);
            command.Parameters.AddWithValue("$id", product.id);
            return command.ExecuteNonQuery() > 0;
        }

        private Product convertToProduct(SqliteDataReader reader)
        {
            Product product = new Product();
            product.id = reader.GetInt16(0);
            product.name = reader.GetString(1);
            product.description = reader.GetString(2);
            product.price = reader.GetDecimal(3);
            product.category = categoryRepository.GetCategpryById(reader.GetInt16(4));
            return product;

        }
    }
}

