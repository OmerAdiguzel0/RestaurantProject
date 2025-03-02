using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DTOLayer.ProductDTO
{
    public class GetProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public bool ProductStatus { get; set; }
        public int CategoryId { get; set; }
    }
}
