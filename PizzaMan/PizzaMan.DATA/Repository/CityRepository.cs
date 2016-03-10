using PizzaMan.Core.Domain;
using PizzaMan.Core.Repository;
using PizzaMan.DATA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMan.DATA.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
