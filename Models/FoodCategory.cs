using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CalorieCount.Models
{
    public class FoodCategory
    {

        public int CategoryId { get; set; }

        [Display(Name ="Category")]
        public string CategoryName { get; set; }    


        //navigation properties
        public List<FoodCategory> Foods { get; set; }
    }
}