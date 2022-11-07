using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CalorieCount.Models
{
    public class DatabaseInitialiser : DropCreateDatabaseAlways<ApplicationDbContext>
    {

        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);


            //if no records stored in users table
            if (!context.Users.Any())
            {
                UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                //creating user accounts
                var brad = new ApplicationUser
                {
                    UserName = "brad@gmail.com",
                    Email = "brad@gmail.com",
                    EmailConfirmed = true,
                };
                userManager.Create(brad, "member");

                var brianna = new ApplicationUser
                {
                    UserName = "brianna@gmail.com",
                    Email = "brianna@gmail.com",
                    EmailConfirmed = true,
                };
                userManager.Create(brianna, "member");

                context.SaveChanges();

                //create some daily calorie intakes

                var day1 = new DailyCalorieIntake
                {
                    IntakeDate = DateTime.Now,
                    User = brad,
                    TotalDailyCalories = 280
                };
                context.DailyCalorieIntakes.Add(day1);

                var day2 = new DailyCalorieIntake
                {
                    IntakeDate = DateTime.Now,
                    User = brianna,
                    TotalDailyCalories = 300
                };
                context.DailyCalorieIntakes.Add(day2);
                context.SaveChanges();

                //create food categories
                var smallFoods = new FoodCategory { CategoryName = "Fruit + Veg" };
                var heavyFoods = new FoodCategory { CategoryName = "Main Meals" };
                var sweetFoods = new FoodCategory { CategoryName = "Desserts" };



                //add them to the FoodCategory table

                context.FoodCategories.Add(smallFoods);
                context.FoodCategories.Add(heavyFoods);
                context.FoodCategories.Add(sweetFoods);

                //save the new changes 
                context.SaveChanges();

                //seed database with foods
                context.Foods.Add(new Food()
                {
                    FoodName = "Apple",
                    ImageUrl = "C:/Users/taylo/OneDrive/Desktop/college/CalorieCount/CalorieCount/CalorieCount/Images/apple.jpg",
                    FoodType = FoodType.Healthy,
                    CalorieAmount = 52,
                    FoodCategory = smallFoods
                });
                context.Foods.Add(new Food()
                {
                    FoodName = "Grapes",
                    ImageUrl = "C:/Users/taylo/OneDrive/Desktop/college/CalorieCount/CalorieCount/CalorieCount/Images/grapes.jpg",
                    FoodType = FoodType.Healthy,
                    CalorieAmount = 67,
                    FoodCategory = smallFoods
                });
                context.Foods.Add(new Food()
                {
                    FoodName = "Melon",
                    ImageUrl = "C:/Users/taylo/OneDrive/Desktop/college/CalorieCount/CalorieCount/CalorieCount/Images/melon.jpg",
                    FoodType = FoodType.Healthy,
                    CalorieAmount = 36,
                    FoodCategory = smallFoods
                });
                context.Foods.Add(new Food()
                {
                    FoodName = "Cheese Burger",
                    ImageUrl = "C:/Users/taylo/OneDrive/Desktop/college/CalorieCount/CalorieCount/CalorieCount/Images/cheeseburger.jpg",
                    FoodType = FoodType.Heavy,
                    CalorieAmount = 303,
                    FoodCategory = heavyFoods
                });
                context.Foods.Add(new Food()
                {
                    FoodName = "Chicken",
                    ImageUrl = "C:/Users/taylo/OneDrive/Desktop/college/CalorieCount/CalorieCount/CalorieCount/Images/chickn.jpg",
                    FoodType = FoodType.Heavy,
                    CalorieAmount = 239,
                    FoodCategory = heavyFoods
                });
                context.Foods.Add(new Food()
                {
                    FoodName = "Pizza",
                    ImageUrl = "C:/Users/taylo/OneDrive/Desktop/college/CalorieCount/CalorieCount/CalorieCount/Images/pizza.jpg",
                    FoodType = FoodType.Heavy,
                    CalorieAmount = 266,
                    FoodCategory = heavyFoods
                });
                context.Foods.Add(new Food()
                {
                    FoodName = "Pork Chops",
                    ImageUrl = "C:/Users/taylo/OneDrive/Desktop/college/CalorieCount/CalorieCount/CalorieCount/Images/pork chops.jpg",
                    FoodType = FoodType.Heavy,
                    CalorieAmount = 231,
                    FoodCategory = heavyFoods
                });
                context.Foods.Add(new Food()
                {
                    FoodName = "Soup",
                    ImageUrl = "C:/Users/taylo/OneDrive/Desktop/college/CalorieCount/CalorieCount/CalorieCount/Images/soup.jpg",
                    FoodType = FoodType.Heavy,
                    CalorieAmount = 74,
                    FoodCategory = heavyFoods
                });
                context.Foods.Add(new Food()
                {
                    FoodName = "Steak",
                    ImageUrl = "C:/Users/taylo/OneDrive/Desktop/college/CalorieCount/CalorieCount/CalorieCount/Images/steak.jpg",
                    FoodType = FoodType.Heavy,
                    CalorieAmount = 271,
                    FoodCategory = heavyFoods
                });
                context.Foods.Add(new Food()
                {
                    FoodName = "Brownie",
                    ImageUrl = "C:/Users/taylo/OneDrive/Desktop/college/CalorieCount/CalorieCount/CalorieCount/Images/brownie.jpg",
                    FoodType = FoodType.Dessert,
                    CalorieAmount = 466,
                    FoodCategory = sweetFoods
                });
                context.Foods.Add(new Food()
                {
                    FoodName = "Carrot Cake",
                    ImageUrl = "C:/Users/taylo/OneDrive/Desktop/college/CalorieCount/CalorieCount/CalorieCount/Images/carrot cake.jpg",
                    FoodType = FoodType.Dessert,
                    CalorieAmount = 415,
                    FoodCategory = sweetFoods
                });
                context.Foods.Add(new Food()
                {
                    FoodName = "Chocolate Cake",
                    ImageUrl = "C:/Users/taylo/OneDrive/Desktop/college/CalorieCount/CalorieCount/CalorieCount/Images/chocolate cake.jpg",
                    FoodType = FoodType.Dessert,
                    CalorieAmount = 371,
                    FoodCategory = sweetFoods
                });

                context.SaveChanges();  
            }
        }

    }
}