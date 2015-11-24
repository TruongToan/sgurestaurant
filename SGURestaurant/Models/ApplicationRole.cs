using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGURestaurant.Models
{
    public class ApplicationRole : IdentityRole
    {
        public virtual string Description { get; set; }

        public ApplicationRole() : base() { }

        public ApplicationRole(string name, string description) : base (name)
        {
            Description = description;
        }
    }
}