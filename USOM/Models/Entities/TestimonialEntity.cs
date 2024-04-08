using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace USOM
{
    [Table("Testimonial")]
    public class TestimonialEntity : BaseEntity
    {
        public string Description { get; set; }

        public string Designation { get; set; }


    }
}