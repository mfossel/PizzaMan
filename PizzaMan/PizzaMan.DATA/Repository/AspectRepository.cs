using PizzaMan.Core.Domain;
using PizzaMan.Core.Repository;
using PizzaMan.DATA.Infrastructure;

namespace PizzaMan.DATA.Repository
{
    public class AspectRepository : Repository<Aspect>, IAspectRepository
    {
        public AspectRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
