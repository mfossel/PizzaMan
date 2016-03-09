using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaMan.Core.Domain;

namespace PizzaMan.Core.Models
{
    class ReviewModel
    {
        public int ReviewId { get; set; }
        public int PizzeriaId { get; set; }
        public Review.Rating Crust { get; set; }
        public Review.Rating Cheese { get; set; }
        public Review.Rating Toppings { get; set; }
        public Review.Rating CustomerService { get; set; }
        public Review.Rating? OtherFoodItems { get; set; }
        public Review.Rating? Drinks { get; set; }
        public Review.Rating OverallExperience { get; set; }
    }
}
