using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebApiTest.Models;

namespace WebApiTest.Areas.Identity.Data;

// Add profile data for application users by adding properties to the BlogUser class
public class BlogUser : IdentityUser
{
    //public virtual ICollection<Content> Posts { get; set; }
}

