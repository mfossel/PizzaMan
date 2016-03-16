using PizzaMan.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMan.DATA.Infrastructure
{
    public class PizzaManDataContext : DbContext
    {
        public PizzaManDataContext() : base("PizzaMan")
        {
            var ensureDllIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        //SQL Tables
        public IDbSet<Photo> Photos { get; set; }
        public IDbSet<Pizzeria> Pizzerias { get; set; }
        public IDbSet<Review> Reviews { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<AspectRating> AspectRatings { get; set;}
        public IDbSet<Aspect> Aspects { get; set; }

        //Model Relationships
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //AspectRatings
            modelBuilder.Entity<AspectRating>().HasKey(ar => new { ar.AspectId, ar.ReviewId });

            //Pizzeria
            modelBuilder.Entity<Pizzeria>()
                        .HasMany(p => p.Reviews)
                        .WithRequired(r => r.Pizzeria)
                        .HasForeignKey(r => r.PizzeriaId);

            modelBuilder.Entity<Pizzeria>()
                         .HasMany(p => p.Photos)
                         .WithRequired(ph => ph.Pizzeria)
                         .HasForeignKey(ph => ph.PizzeriaId);

            //Review
            modelBuilder.Entity<Review>()
                        .HasMany(r => r.AspectRatings)
                        .WithRequired(a => a.Review)
                        .HasForeignKey(a => a.ReviewId);

            //User
            modelBuilder.Entity<User>()
                        .HasMany(u => u.Reviews)
                        .WithRequired(r => r.User)
                        .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<User>()
                         .HasMany(u => u.Photos)
                         .WithRequired(ph => ph.User)
                         .HasForeignKey(ph => ph.UserId);

 

            base.OnModelCreating(modelBuilder);
        }


    }
}
