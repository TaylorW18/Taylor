using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CalorieCount.Models
{
    public class DailyCalorieIntake
    {
        [Key]
        public int DailyCalorieIntakeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime IntakeDate { get; set; }

        public int TotalDailyCalories { get; set; }

        //calc total daily intake
        public void CalculateTotalDailyCalories(int calorieAmount)
        {
            TotalDailyCalories = TotalDailyCalories + calorieAmount;
        }

        //sets the total daily calorie to zero
        public void ResetTotalDailyCalorie()
        {
            TotalDailyCalories = 0;
        }

        //nav property
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }  
    }
}