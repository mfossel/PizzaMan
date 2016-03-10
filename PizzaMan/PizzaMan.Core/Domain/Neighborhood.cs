﻿using PizzaMan.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMan.Core.Domain
{
    public class Neighborhood
    {
        public int NeighborhoodId { get; set; }
        public int CityId { get; set; }
        public string NeighborhoodName { get; set; }
        public int ZipCode { get; set; }

        public virtual City City { get; set; }
        public ICollection<Pizzeria> Pizzerias { get; set; }

        public Neighborhood() { }

        public Neighborhood(NeighborhoodModel model)
        {
            this.Update(model);
        }

        public void Update(NeighborhoodModel model)
        {
            NeighborhoodId = model.NeighborhoodId;
            CityId = model.CityId;
            NeighborhoodName = model.NeighborhoodName;
            ZipCode = model.ZipCode;
        }
    }
}
