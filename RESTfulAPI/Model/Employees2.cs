using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfulAPI.Model
{
    public class Employees2
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Division { get; set; }
        public string Rank { get; set; }
    }
}
