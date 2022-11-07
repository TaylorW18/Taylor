using Fluent.Infrastructure.FluentModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace CalorieCount.Models
{
    public class ApplicationUser : IdentityUser
    {

        //nav property 
        public List<DailyCalorieIntake> DailyCalorieIntakes { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            //Authenticationtype must match the one defined
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            //Add custom claims here 
            return userIdentity;
        }

    }

    public  class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Message> Messages { get; set; } 

        public DbSet<FoodCategory> FoodCategories { get; set; } 
        public DbSet<Food> Foods { get; set; }

        public DbSet<DailyCalorieIntake> DailyCalorieIntakes { get; set; }

        public ApplicationDbContext()
            : base("CalorieCountDbConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new DatabaseInitialiser());
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
