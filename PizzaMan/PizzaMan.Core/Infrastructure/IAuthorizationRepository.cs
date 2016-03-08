using Microsoft.AspNet.Identity;
using PizzaMan.Core.Domain;
using PizzaMan.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMan.Core.Infrastructure
{
    public interface IAuthorizationRepository : IDisposable
    {
        Task<User> FindUser(string username, string password);
        Task<IdentityResult> RegisterUser(RegistrationModel model);
    }
}
