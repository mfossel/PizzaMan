using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMan.Core.Domain
{
    class Review
    {
        public enum Rating
        {
            Poor = 1,
            Mediocre = 2,
            Good = 3,
            Excellent = 4,
            Superb = 5
        }

        public Rating Crust { get; set; }
        public Rating Cheese { get; set; }
        public Rating Toppings { get; set; }
        public Rating CustomerService { get; set;}
        public Rating? OtherFoodItems { get; set; }
        public Rating? Drinks { get; set; }
        public Rating OverallExperience { get; set; }




    }
}
