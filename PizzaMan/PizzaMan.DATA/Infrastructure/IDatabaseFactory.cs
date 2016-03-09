using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMan.DATA.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        PizzaManDataContext GetDataContext();
    }
}
