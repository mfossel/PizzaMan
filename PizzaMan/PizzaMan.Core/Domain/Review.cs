using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMan.Core.Domain
{
    public class Review
    {
        public enum Rating
        {
            Poor = 1,
            Mediocre = 2,
            Good = 3,
            Excellent = 4,
            Superb = 5
        }

        public int ReviewId { get; set; }
        public int PizzeriaId { get; set; }
        public string UserId { get; set; }
        public Rating Crust { get; set; }
        public Rating Cheese { get; set; }
        public Rating Toppings { get; set; }
        public Rating CustomerService { get; set;}
        public Rating? OtherFoodItems { get; set; }
        public Rating? Drinks { get; set; }
        public Rating OverallExperience { get; set; }

        public Pizzeria Pizzeria { get; set; }
        public User User { get; set; }



    }
}
