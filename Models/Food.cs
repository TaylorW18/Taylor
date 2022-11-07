using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CalorieCount.Models
{
    public class Food
    {
        public int FoodId { get; set; }

        [Display(Name ="Food")]
        public string FoodName { get; set; }//what the food is

        [Display(Name = "Food Type")]
        public FoodType FoodType { get; set; }//dessert, healthy, heavy

        [Display(Name = "Food Calories")]
        public int CalorieAmount { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        //nav property

        [ForeignKey("FoodCategory")]
        public int FoodCategoryId { get; set; }
        public FoodCategory FoodCategory { get; set; }

    }
    public enum FoodType { Healthy, Heavy, Dessert}

}