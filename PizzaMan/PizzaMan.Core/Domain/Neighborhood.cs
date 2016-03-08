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


    }
}
