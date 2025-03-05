using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccessLayer.Abstract;
using Restaurant.DataAccessLayer.Concrete;
using Restaurant.DataAccessLayer.Repositories;
using Restaurant.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DataAccessLayer.EntityFramework
{
    public class EFProductDal : GenericRepository<Product>, IProductDal
    {
        public EFProductDal(RestaurantContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new RestaurantContext();
            return context.Products.Include(x=>x.Category).ToList();
            
        }

        public int ProductCount()
        {
            using var context = new RestaurantContext();
            return context.Products.Count();
        }

        public int ProductCountByCategoryNameDrink()
        {
            using var context = new RestaurantContext();
            return context.Products.Where(x=>x.CategoryId==(context.Categories.Where(y=>y.CategoryName=="İçecek").Select(z=>z.CategoryId).FirstOrDefault())).Count();
        }

        public int ProductCountByCategoryNameHamburger()
        {
            using var context = new RestaurantContext();
            return context.Products.Where(x => x.CategoryId == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryId).FirstOrDefault())).Count();
        }

        public string ProductNamePriceByMax()
        {
            using var context = new RestaurantContext();
            return context.Products.Where(x=>x.Price==(context.Products.Max(y=>y.Price))).Select(z=>z.ProductName).FirstOrDefault();
        }

        public string ProductNamePriceByMin()
        {
            using var context = new RestaurantContext();
            return context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }

        public decimal ProductPriceAvg()
        {
            using var context = new RestaurantContext();
            return context.Products.Average(x=>x.Price);
        }
    }
}
