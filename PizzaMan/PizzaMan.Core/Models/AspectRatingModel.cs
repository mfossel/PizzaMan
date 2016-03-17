using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMan.Core.Models
{
    public class AspectRatingModel
    {
        public int AspectRatingId { get; set; }
        public int AspectId { get; set; }
        public int ReviewId { get; set; }

        public float Rating { get; set; }

        public AspectModel Aspect { get; set; }

    }
}
