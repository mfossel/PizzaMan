using PizzaMan.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMan.Core.Domain
{

    public class AspectRating
    {
        public int AspectId { get; set; }
        public int ReviewId { get; set; }

        public float Rating { get; set; }

        public virtual Review Review { get; set; }
        public virtual Aspect Aspect { get; set; }

        public AspectRating() { }

        public AspectRating(AspectRatingModel model)
        {
            this.Update(model);
        }

        public void Update(AspectRatingModel model)
        {
            
            AspectId = model.AspectId;
            ReviewId = model.ReviewId;
            Rating = model.Rating;

        }
    }
}
