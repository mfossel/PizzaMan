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
        public decimal OverallRating { get; set; }

        public PizzeriaModel Pizzeria { get; set; }
        public ICollection<AspectRatingModel> AspectRatings { get; set; }
    }
}
