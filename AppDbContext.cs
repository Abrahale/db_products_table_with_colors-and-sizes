using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public DbSet<Product> Products { get; set; }
        //public DbSet<Color> Colors { get; set; }
        //public DbSet<Size> Sizes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=DbTestPOS;Trusted_Connection=True;");
        }
    }
    //Solution one- have a barcode which is the same for same color and size
    //Solution two- have a different product table for different kinds of items, since not all products require color and size
    public class Product
    {
        public int ProductId { get; set; }
        public int Barcode { get; set; }
        public string ProductName { get; set; }
        public DateTimeOffset AddedDate { get; set; }
        public double StockPrice { get; set; }
        public double SellingPrice { get; set; }
        public string ColorsAndSizes { get; set; }
        public int Qty { get; set; }
    }
    public class ColorsAndSizes
    {
        public string ColorName { get; set; }
        public string ColorProperty { get; set; }
        public List<Sizes> Sizes {get;set;}
        public override string ToString()
        {
            return $"{ColorName} {ColorProperty}";
        }
    }

    public class Sizes
    {
        public string Size { get; set; }
        public int qty { get; set; }

        public override string ToString()
        {
            return $"{Size} {qty}";
        }
    }
}
