using System;
using Microsoft.Data.Sqlite;
using Products.Models;

namespace Products.Repository
{
	public class CategoryRepository : Repository
	{
        
        public CategoryRepository() : base()
        {
          
        }
        public Category? GetCategpryById(int id)
        {
            var command = connection.CreateCommand();
            command.CommandText = @"select * from categories where id= $id";
            command.Parameters.AddWithValue("$id", id);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                    return convertToCategory(reader);
            }
            return null;
        }

    



        public List<Category> getAll()
        {
            List<Category> categories = new List<Category>();
            var command = connection.CreateCommand();
            command.CommandText = @"select * from categories";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                    categories.Add(convertToCategory(reader));
            }
            return null;
        }
        public bool Insert(Category category)
        {
            var command = connection.CreateCommand();
            command.CommandText = @"insert into categories(name) values($name)";
            command.Parameters.AddWithValue("$name", category.name);
            return command.ExecuteNonQuery() > 0;

        }
        public bool Delete(int id)
        {
            var command = connection.CreateCommand();
            command.CommandText = @"delete categories where id= $id";
            command.Parameters.AddWithValue("$id", id);
            return command.ExecuteNonQuery() > 0;

        }
        public bool Update(Category category)
        {
            var command = connection.CreateCommand();
            command.CommandText = @"update categories set name=$name where id= $id";
            command.Parameters.AddWithValue("$name", category.name);
            command.Parameters.AddWithValue("$id", category.id);
            return command.ExecuteNonQuery() > 0;
        }

        
        private Category convertToCategory(SqliteDataReader reader)
        {

            Category category = new Category();
            category.id = reader.GetInt16(0);
            category.name = reader.GetString(1);
            return category;
        }
    }

}

