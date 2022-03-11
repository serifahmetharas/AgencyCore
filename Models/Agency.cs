using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgencyCore.Models
{
    public class Agency
    {
        [Key]
        public int AgencyId { get; set; }
        public string AgencyName { get; set; }
        public IList<Customer> Customers { get; set; }
    }
}
