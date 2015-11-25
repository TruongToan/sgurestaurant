using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGURestaurant.Models
{
    public class ApplicationUserRole : IdentityRole
    {
        public ApplicationUserRole() : base() { }

        public ApplicationRole Role { get; set; }
    }
}