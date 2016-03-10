using PizzaMan.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMan.Core.Domain
{
    public enum Rating
    {
        Poor = 1,
        Mediocre = 2,
        Good = 3,
        Excellent = 4,
        Superb = 5
    }

    public class Review
    {
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

        public Review() { }

        public Review(ReviewModel model)
        {
            this.Update(model);
        }

        public void Update(ReviewModel model)
        {
            ReviewId = model.ReviewId;
            PizzeriaId = model.PizzeriaId;
            UserId = model.UserId;
            Crust = model.Crust;
            Cheese = model.Cheese;
            Toppings = model.Toppings;
            CustomerService = model.CustomerService;
            OtherFoodItems = model.OtherFoodItems;
            Drinks = model.Drinks;
            OverallExperience = model.OverallExperience;

        }

    }
}
