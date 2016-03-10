using Microsoft.AspNet.Identity;
using PizzaMan.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMan.Core.Domain
{
    public class User : IUser<string>
    {
        public string Id { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }

        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<Review> Reviews { get; set; }

        public User() { }

        public User(UserModel model)
        {
            this.Update(model);
        }

        public void Update(UserModel model)
        {
            Id = model.Id;
            EmailAddress = model.EmailAddress;
            UserName = model.UserName;
            PasswordHash = model.PasswordHash;
            SecurityStamp = model.SecurityStamp;
        }
    }
}
