using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogRazor.Models
{
    public class BloggerModel
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string Sex { get; set; }
        public string Sign { get; set; }
        [DataType(DataType.Date)]
        public DateTime RegistDate { get; set; }
    }
}