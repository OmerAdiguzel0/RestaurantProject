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
    public class EFCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EFCategoryDal(RestaurantContext context) : base(context)
        {
        }

        public int ActiveCategoryCount()
        {
            using var context = new RestaurantContext();
            return context.Categories.Where(x => x.CategoryStatus == true).Count();
        }

        public int CategoryCount()
        {
            using var context = new RestaurantContext();
            return context.Categories.Count();
        }

        public int PassiveCategoryCount()
        {
            using var context = new RestaurantContext();
            return context.Categories.Where(x => x.CategoryStatus == false).Count();
        }
    }
}
