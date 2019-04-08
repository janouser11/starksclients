using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StarkIndustries.Data.DbModels
{
    public class Agent
    {
        [Key]
        public int _id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int Tier { get; set; }
        public Phone Phone { get; set; }
        public List<Customer> Customers { get; set; }
    }

    [Owned]
    public class Phone
    {
        public string Primary { get; set; }
        public string Mobile { get; set; }
    }


}
