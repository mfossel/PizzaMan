using PizzaMan.Core.Domain;
using PizzaMan.Core.Repository;
using PizzaMan.DATA.Infrastructure;

namespace PizzaMan.DATA.Repository
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
