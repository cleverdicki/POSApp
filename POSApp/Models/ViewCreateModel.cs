using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POSApp.Models
{
    public class ViewCreateModel
    {
        public Food FoodModel { get; set; }
        public IEnumerable<Food> FoodView { get; set; }

    }
}