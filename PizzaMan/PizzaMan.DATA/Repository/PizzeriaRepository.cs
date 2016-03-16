using PizzaMan.Core.Domain;
using PizzaMan.Core.Repository;
using PizzaMan.DATA.Infrastructure;

namespace PizzaMan.DATA.Repository
{
    public class PizzeriaRepository : Repository<Pizzeria>, IPizzeriaRepository
    {
        public PizzeriaRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
