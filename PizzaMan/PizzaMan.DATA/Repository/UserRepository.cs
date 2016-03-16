using PizzaMan.Core.Domain;
using PizzaMan.Core.Repository;
using PizzaMan.DATA.Infrastructure;

namespace PizzaMan.DATA.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
