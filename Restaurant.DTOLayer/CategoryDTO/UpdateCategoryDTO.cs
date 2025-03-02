using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DTOLayer.CategoryDTO
{
    public class UpdateCategoryDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
    }
}
