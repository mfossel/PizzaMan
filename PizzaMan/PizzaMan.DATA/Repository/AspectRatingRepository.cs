using PizzaMan.Core.Domain;
using PizzaMan.Core.Repository;
using PizzaMan.DATA.Infrastructure;

namespace PizzaMan.DATA.Repository
{
    public class AspectRatingRepository : Repository<AspectRating>, IAspectRatingRepository
    {
        public AspectRatingRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
