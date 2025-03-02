using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Dtos.DiscountDtos
{
    public class UpdateDiscountDTO
    {
        public int DiscountId { get; set; }
        public string Title { get; set; }
        public string Amount { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
    }
}
