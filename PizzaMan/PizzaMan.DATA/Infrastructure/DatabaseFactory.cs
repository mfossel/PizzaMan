using PizzaMan.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMan.DATA.Infrastructure
{
   
        public class DatabaseFactory : Disposable, IDatabaseFactory
        {
            private readonly PizzaManDataContext _dataContext;

            public PizzaManDataContext GetDataContext()
            {
                return _dataContext ?? new PizzaManDataContext();
            }

            public DatabaseFactory()
            {
                _dataContext = new PizzaManDataContext();
            }

            protected override void DisposeCore()
            {
                if (_dataContext != null) _dataContext.Dispose();
            }
        }
    
}
