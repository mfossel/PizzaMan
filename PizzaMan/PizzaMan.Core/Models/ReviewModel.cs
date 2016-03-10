using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaMan.Core.Domain;

namespace PizzaMan.Core.Models
{
    public class ReviewModel
    {
        public int ReviewId { get; set; }
        public int PizzeriaId { get; set; }
        public string UserId { get; set; }
        public Rating Crust { get; set; }
        public Rating Cheese { get; set; }
        public Rating Toppings { get; set; }
        public Rating CustomerService { get; set; }
        public Rating? OtherFoodItems { get; set; }
        public Rating? Drinks { get; set; }
        public Rating OverallExperience { get; set; }
    }
}
