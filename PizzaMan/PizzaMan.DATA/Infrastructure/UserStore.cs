using Microsoft.AspNet.Identity;
using PizzaMan.Core.Domain;
using PizzaMan.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMan.DATA.Infrastructure
{
    public class UserStore : Disposable,
                            IUserPasswordStore<User, string>,
                            IUserSecurityStampStore<User, string>
    {
        private readonly IDatabaseFactory _databaseFactory;

        private PizzaManDataContext _dataContext;
        protected PizzaManDataContext DataContext
        {
            get
            {
                return _dataContext ?? (_dataContext = _databaseFactory.GetDataContext());
            }
        }

        public UserStore(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        #region IUserPasswordStore
        public Task CreateAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return Task.Factory.StartNew(() =>
            {
                user.Id = Guid.NewGuid().ToString();
                DataContext.Users.Add(user);
                DataContext.SaveChanges();
            });
        }

        public Task DeleteAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return Task.Factory.StartNew(() =>
            {
                DataContext.Users.Remove(user);
                DataContext.SaveChanges();
            });
        }

        public Task<User> FindByIdAsync(string userId)
        {
            return Task.Factory.StartNew(() =>
            {
                return DataContext.Users.FirstOrDefault(u => u.Id == userId);
            });
        }

        public Task<User> FindByNameAsync(string userName)
        {
            return Task.Factory.StartNew(() =>
            {
                return DataContext.Users.FirstOrDefault(u => u.UserName == userName);
            });
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return Task.Factory.StartNew(() =>
            {
                return user.PasswordHash;
            });
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            user.PasswordHash = passwordHash;

            return Task.FromResult(0);
        }

        public Task UpdateAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return Task.Factory.StartNew(() =>
            {
                DataContext.Users.Attach(user);
                DataContext.Entry(user).State = EntityState.Modified;

                DataContext.SaveChanges();
            });
        }
        #endregion

        #region ISecurityStampStore
        public Task<string> GetSecurityStampAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.SecurityStamp);
        }

        public Task SetSecurityStampAsync(User user, string stamp)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            user.SecurityStamp = stamp;

            return Task.FromResult(0);
        }
        #endregion

    }
}