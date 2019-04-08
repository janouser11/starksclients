using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarkIndustries.Domain.Customers
{

    public class CustomerModel
    {

    public int _id { get; set; }
    public int Agent_id { get; set; }
    public string Guid { get; set; }
    public bool IsActive { get; set; }
    public string Balance { get; set; }
    public int Age { get; set; }
    public string EyeColor { get; set; }
    public Name Name { get; set; }
    public string Company { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Registered { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public List<string> Tags { get; set; }
}

public class Name
{
    public string First { get; set; }
    public string Last { get; set; }
}


}

