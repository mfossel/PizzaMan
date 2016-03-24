using Microsoft.AspNet.Identity;
using PizzaMan.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public string ZipCode { get; set; }

        //TOTO: Remove security risk
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }

        public int NumberOfReviews
        {
            get
            {
                return Reviews.Count == 0
                    ? 0
                    : Reviews.Count;
            }
        }

        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public User() {
            Reviews = new Collection<Review>();
        }

        public User(UserModel model) : this()
        {
            this.Update(model);
        }

        public void Update(UserModel model)
        {
            Id = model.Id;
            EmailAddress = model.EmailAddress;
            UserName = model.UserName;
            ZipCode = model.ZipCode;
            PasswordHash = model.PasswordHash;
            SecurityStamp = model.SecurityStamp;
        }
    }
}
