﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Dtos.TestimonialDtos
{
    public class CreateTestimonialDTO
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImagURL { get; set; }
        public bool Status { get; set; }

    }
}
