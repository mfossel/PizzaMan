﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMan.Core.Domain
{
    class Pizzeria
    {
        public int PizzeriaId { get; set; }
        public string Type { get; set; }
        public string Style { get; set; }
        public bool Delivery { get; set; }
        public bool Takeout { get; set; }
        public bool Sitdown { get; set; }
        public bool Alcohol { get; set; }
        public string PhoneNumber { get; set; }
        public string DrinkSelection { get; set; }
        public string MenuURL { get; set; }
        public string OvenType { get; set; }
        public bool GlutenFreeOption { get; set; }
        public bool VeganOption { get; set; }


       


    }
}
