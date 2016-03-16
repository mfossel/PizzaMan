using PizzaMan.Core.Domain;
using PizzaMan.Core.Repository;
using PizzaMan.DATA.Infrastructure;

namespace PizzaMan.DATA.Repository
{
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        public PhotoRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
