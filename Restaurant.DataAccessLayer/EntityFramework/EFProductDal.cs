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
    }
}
