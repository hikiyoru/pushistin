using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using pushistin.Models;
using Microsoft.AspNetCore.Identity;

namespace pushistin.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string? Name { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public int? Home { get; set; }
    public int? FrontDoor { get; set; }
    public int? Apartament { get; set; }
}


public class ApplicationRole : IdentityRole
{

}
