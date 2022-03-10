using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAgency.Models
{
    public class Agency
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
