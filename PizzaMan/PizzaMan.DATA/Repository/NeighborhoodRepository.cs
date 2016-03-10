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
    public class NeighborhoodRepository : Repository<Neighborhood>, INeighborhoodRepository
    {
        public NeighborhoodRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
