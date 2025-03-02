using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Dtos.AboutDtos
{
    public class UpdateAboutDTO
    {
        public int AboutId { get; set; }
        public string ImageURL { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
