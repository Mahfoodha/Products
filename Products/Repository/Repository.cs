using System;
using Microsoft.Data.Sqlite;

namespace Products.Repository
{
	public class Repository
	{
        protected SqliteConnection connection;
        public Repository()
		{
            connection = new SqliteConnection("Data Source=products.db");
            var command = connection.CreateCommand();
            command.CommandText = @"create table if not exist categories (
             id int primary key AUTOINCREMENT, name text)";
            command.ExecuteNonQuery();

            var command2 = connection.CreateCommand();
            command2.CommandText = @"create table if not exist products (
             id int primary key AUTOINCREMENT, name text,description text,price real,category int,
             FOREIGN KEY(category) REFERENCES category(id))";
            command2.ExecuteNonQuery();
        }
	}
}

