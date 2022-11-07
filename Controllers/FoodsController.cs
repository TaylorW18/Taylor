using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CalorieCount.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CalorieCount.Controllers
{
    public class FoodsController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public ActionResult ResetDailyCalorie()
        {
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //get the current user's ID
            string userId = userManager.FindByEmail(User.Identity.GetUserName()).Id;
            //get the user
            ApplicationUser user = context.Users.Find(userId);
            //get the daily calorie intake of current date
            DailyCalorieIntake dailyIntake = context.DailyCalorieIntakes
                .Where(d => DbFunctions.TruncateTime(d.IntakeDate) == DateTime.Today)
                .SingleOrDefault(d => d.UserId.Equals(userId));

            //if this is the first entry of the day then create a dailycalorieintake and add the calories to the total
            if (dailyIntake == null)
            {
                DailyCalorieIntake dci = new DailyCalorieIntake
                {
                    IntakeDate = DateTime.Now.Date,
                    User = user
                };

                dci.ResetTotalDailyCalorie();
                context.DailyCalorieIntakes.Add(dci);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            //if there is already an entry for the current date then just set the total daily calorie to zero
            dailyIntake.ResetTotalDailyCalorie();
            context.Entry(dailyIntake).State = EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Foods
        public ActionResult Index()
        {
            //get all foods
            var foods = context.Foods.ToList();

            foreach (var item in foods)
            {
                context.Entry(item).Reload();
            }

            //send all foods to viewbag
            ViewBag.Categories = context.FoodCategories.ToList();

            //send all food categories in a viewbag
            ViewBag.Categories = context.FoodCategories.ToList();

            //send the users updated daily calorie intake to display on the page
            //get the user id
            string id = User.Identity.GetUserId();
            //if user is logged in (id will be not null)
            if (id != null)
            {

                //then get the current user's daily calorie intake for the current date 
                DailyCalorieIntake dailyIntake = context.DailyCalorieIntakes
                    .Where(d => DbFunctions.TruncateTime(d.IntakeDate) == DateTime.Today)
                    .SingleOrDefault(d => d.UserId.Equals(id));

                //if there is a current daily calorie intake recorded then send the total calorie at the view bag using viewbag
                if (dailyIntake != null)
                {
                    ViewBag.TotalCalories = dailyIntake.TotalDailyCalories;
                }
            }
            //send the products to the product view
            return View("FoodsView", foods);
        }
        public ActionResult AddToDailyCalorie(int calorie)
        {
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //get the current user's ID
            string userId = userManager.FindByEmail(User.Identity.GetUserName()).Id;
            //get the user
            ApplicationUser user = context.Users.Find(userId);
            //get the daily calorie intake of current date
            DailyCalorieIntake dailyIntake = context.DailyCalorieIntakes
                .Where(d => DbFunctions.TruncateTime(d.IntakeDate) == DateTime.Today)
                .SingleOrDefault(d => d.UserId.Equals(userId));

            //if this is the first entry of the day then create a dailycalorieintake and add the calories to the total
            if (dailyIntake==null)
            {
                DailyCalorieIntake dci = new DailyCalorieIntake
                {
                    IntakeDate = DateTime.Now.Date,
                    User = user
                };

                dci.CalculateTotalDailyCalories(calorie);
                context.DailyCalorieIntakes.Add(dci);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            //get the daily calorie intake of current dtae
            DailyCalorieIntake dailyIntake2 = context.DailyCalorieIntakes.Where(d => DbFunctions.TruncateTime(d.IntakeDate) == DateTime.Today).SingleOrDefault();


            //if there is already an entyr for the current date then just update the total daily calories 
            dailyIntake.CalculateTotalDailyCalories(calorie);
            context.Entry(dailyIntake2).State = EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Foods(int? id)
        {
            //get all foods that are in a specific category
            var foods = context.Foods.Where(p => p.FoodCategoryId == id).ToList();
            //send all in viewbag
            ViewBag.Categories = context.FoodCategories.ToList();

            //send the users updated daily calorie intake to display on the page
            //get the user id
            string userId = User.Identity.GetUserId();
            //if user is logged in (id will be not null)
            if (userId != null)
            {

                //then get the current user's daily calorie intake for the current date 
                DailyCalorieIntake dailyIntake = context.DailyCalorieIntakes
                    .Where(d => DbFunctions.TruncateTime(d.IntakeDate) == DateTime.Today)
                    .SingleOrDefault(d => d.UserId.Equals(id));

                //if there is a current daily calorie intake recorded then send the total calorie at the view bag using viewbag
                if (dailyIntake != null)
                {
                    ViewBag.TotalCalories = dailyIntake.TotalDailyCalories;
                }
            }

            return View("FoodsView", foods);

        }
    }
}