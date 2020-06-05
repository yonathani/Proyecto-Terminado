using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MioBarber.Migrations;
using MioBarber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MioBarber.clase
{
    public class Utilities
    {
        readonly static ApplicationDbContext db = new ApplicationDbContext();
        public static void CheckRoles(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
        }

        internal static void CheckSuperUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userAsp = userManager.FindByName("admin@adminmail.com");

            if (userAsp == null)
            {
                CreateUserASP("admin@adminmail.com", "admin2030", "Admin");
            }
        }

        private static void CreateUserASP(string email, string password, string rol)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userId = new ApplicationUser()
            {
                UserName = email,
                Email = email,
            };

          
        }

        internal static void CheckClientDefault()
        {
            var clientdb = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userclient = clientdb.FindByName("barbero@miobarber.com");
            if (userclient == null)
            {
                CreateUserASP("barbero@miobarber.com", "barbero123", "Barberos");
                userclient = clientdb.FindByName("barbero@miobarber.com");
            }
        }

        public void Dipose()
        {
            db.Dispose();
        }

    }
}
