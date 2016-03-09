using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMan.Core.Domain
{
    public class Photo
    {
        public int PhotoId { get; set}
        public int PizzeriaId { get; set; }
        public string PhotoURL { get; set; }
        public int NumberOfLikes { get; set; }

        public Pizzeria Pizzeria { get; set; }
        public User User { get; set; }


    }
}
