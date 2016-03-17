using PizzaMan.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMan.Core.Domain
{

    public class Review
    {
        public int ReviewId { get; set; }
        public int PizzeriaId { get; set; }
        public string UserId { get; set; }


        public virtual Pizzeria Pizzeria { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<AspectRating> AspectRatings { get; set; }


        public float OverallRating
        {
            get
            {
                return AspectRatings.Count == 0 
                    ? 0 
                    : AspectRatings.Average(a => a.Rating);
            }
        }



        public Review()
        {
            AspectRatings = new Collection<AspectRating>();
        }

        public Review(ReviewModel model) : this()
        {
            this.Update(model);
        }

        public void Update(ReviewModel model)
        {
            ReviewId = model.ReviewId;
            PizzeriaId = model.PizzeriaId;
            UserId = model.UserId;
            foreach (var aspect in model.AspectRatings)
            {
                AspectRatings.Add(new AspectRating(aspect));
            }
        }

    }
}
