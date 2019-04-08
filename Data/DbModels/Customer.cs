using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StarkIndustries.Data.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


    public class Customer
{
    
    public int _id { get; set; }
    public int Agent_id { get; set; }
    [Key]
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
    public List<Tag> Tags { get; set; }
    public Agent Agent { get; set; }
}

[Owned]
public class Name
{
    public string First { get; set; }
    public string Last { get; set; }
}

[Owned]
public class Tag
{
    [Key]
    public int TagId { get; set; }
    public string TagName { get; set; }
}

