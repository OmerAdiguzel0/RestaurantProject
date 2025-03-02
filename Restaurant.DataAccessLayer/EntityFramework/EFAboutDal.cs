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
    public class EFAboutDal : GenericRepository<About>, IAboutDal
    {
        public EFAboutDal(RestaurantContext context) : base(context)
        {
        }
    }
}
