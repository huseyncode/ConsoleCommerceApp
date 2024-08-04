using Core.Entities.UserEntities;
using Data.Contexts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DbInitilaizer
    {
        private static readonly AppDbContext _contex;
        static DbInitilaizer()
        {
            _contex = new AppDbContext();
        }

        public static void SeedData()
        {
            SeedAdmin();
        }
        private static void SeedAdmin()
        {
            if (!_contex.Admins.Any())
            {
                Admin admin = new Admin
                {
                    Name = "Admin",
                    Surname = "Admin",
                    Email = "Admin@gmail.com"
                };
                PasswordHasher<Admin> passwordHasher = new PasswordHasher<Admin>();
                admin.Password = passwordHasher.HashPassword(admin, "Admin2003");
                _contex.Admins.Add(admin);
                try
                {
                    _contex.SaveChanges();
                }
                catch (Exception)
                {
                    

                }
            }
        }



    }
}
