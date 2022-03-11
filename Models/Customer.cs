using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgencyCore.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

        public int AgencyId { get; set; }
        public Agency Agency { get; set; }



    }
}
