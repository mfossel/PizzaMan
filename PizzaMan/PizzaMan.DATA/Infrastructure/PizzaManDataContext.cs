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
        public IDbSet<City> Cities { get; set; }
        public IDbSet<Neighborhood> Neighborhoods { get; set; }
        public IDbSet<Photo> Photos { get; set; }
        public IDbSet<Pizzeria> Pizzerias { get; set; }
        public IDbSet<Review> Reviews { get; set; }
        public IDbSet<User> Users { get; set; }

        //Model Relationships
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            //City
            modelBuilder.Entity<City>()
                        .HasMany(c => c.Neighborhoods)
                        .WithRequired(n => n.City)
                        .HasForeignKey(n => n.CityId);

            //Neighborhood
            modelBuilder.Entity<Neighborhood>()
                        .HasMany(n => n.Pizzerias)
                        .WithRequired(p => p.Neighborhood)
                        .HasForeignKey(p => p.NeighborhoodId);

            //Pizzeria
            modelBuilder.Entity<Pizzeria>()
                        .HasMany(p => p.Reviews)
                        .WithRequired(r => r.Pizzeria)
                        .HasForeignKey(r => r.PizzeriaId);

            modelBuilder.Entity<Pizzeria>()
                         .HasMany(p => p.Photos)
                         .WithRequired(ph => ph.Pizzeria)
                         .HasForeignKey(ph => ph.PizzeriaId);

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
