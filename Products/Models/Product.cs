using System;
namespace Products.Models
{
	public class Product
	{
		public Product()
		{
		}

        public short id { get;  set; }
        public string name { get;  set; }
        public Category category { get;  set; }
        public string description { get; internal set; }
        public decimal price { get; internal set; }
    }
}

