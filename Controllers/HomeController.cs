using CalorieCount.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalorieCount.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        [HttpGet]
        public ActionResult Contact()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Contact(Message message)
        {
            if (ModelState.IsValid)
            {
                message.DateOfMessage = DateTime.Now.Date;
                context.Messages.Add(message);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(message);
        }                                                          
        public ActionResult SplashScreen()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }
       
        public ActionResult Sounds()
        {
            //audio files will be stored here 
            List<Sound> sounds = new List<Sound>();

            sounds.Add(new Sound { Name = "First Fast", FilePath = "C:/Users/taylo/OneDrive/Desktop/college/CalorieCount/CalorieCount/CalorieCount/Sounds/5_2_Diet_Podcast_Ep_2_Planning_for_your_first_fast.mp3" });
            sounds.Add(new Sound { Name = "Survival Guide", FilePath = "C:/Users/taylo/OneDrive/Desktop/college/CalorieCount/CalorieCount/CalorieCount/Sounds/5_2_Diet_Podcast_Ep_3_Your_fast_day_survival_guide.mp3" });
            sounds.Add(new Sound { Name = "What to Eat on a Fat Day", FilePath = "C:/Users/taylo/OneDrive/Desktop/college/CalorieCount/CalorieCount/CalorieCount/Sounds/5_2_Diet_Podcast_Ep_4_What_to_Eat_on_a_Fast_Day_-_a_menu_of_food_ideas_Jan_2015.mp3" });
            sounds.Add(new Sound { Name = "How to Love Your Food", FilePath = "C:/Users/taylo/OneDrive/Desktop/college/CalorieCount/CalorieCount/CalorieCount/Sounds/5_2_Diet_Podcast_Ep_5_-_how_to_love_your_food_on_non-fast_days_without_overdoing_it.mp3" });
            sounds.Add(new Sound { Name = "Flexible", FilePath = "C:/Users/taylo/OneDrive/Desktop/college/CalorieCount/CalorieCount/CalorieCount/Sounds/5_2_Diet_Podcast_Ep_6_Your_flexible_5_2_diet.mp3" });
            sounds.Add(new Sound { Name = "Foodie Fasting", FilePath = "C:/Users/taylo/OneDrive/Desktop/college/CalorieCount/CalorieCount/CalorieCount/Sounds/5_2_Diet_Podcast_Ep_9_Foodie_fasting_in_France_Belinda_Berry.mp3" });


            //send the list of podcasts to the view
            return View(sounds);
        }
    }
}