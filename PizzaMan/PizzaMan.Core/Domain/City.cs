using PizzaMan.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMan.Core.Domain
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string State { get; set; }
        
        public ICollection<Neighborhood> Neighborhoods { get; set; }

        public City() { }

        public City(CityModel model)
        {
            this.Update(model);
        }

        public void Update(CityModel model)
        {
            CityId = model.CityId;
            CityName = model.CityName;
            State = model.State;

        }




    }
}
