using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
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

    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(
            IRoleStore<ApplicationRole, string> roleStore)
            : base(roleStore)
        {
        }
        public static ApplicationRoleManager Create(
            IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(
                new RoleStore<ApplicationRole>(context.Get<SGURestaurantContext>()));
        }
    }
}