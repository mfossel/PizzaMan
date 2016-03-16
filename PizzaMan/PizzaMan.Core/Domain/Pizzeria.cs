using PizzaMan.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMan.Core.Domain
{
    public class Pizzeria
    {
        public int PizzeriaId { get; set; }
        public string PizzeriaName { get; set; }
        public int YearOpened { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Style { get; set; }
        public string Description { get; set; }
        public bool Delivery { get; set; }
        public bool Takeout { get; set; }
        public bool Sitdown { get; set; }
        public bool Alcohol { get; set; }
        public string PhoneNumber { get; set; }
        public string MenuURL { get; set; }
        public string OvenType { get; set; }
        public bool GlutenFreeOption { get; set; }
        public bool VeganOption { get; set; }

        public float AverageRating
        {
            get
            {
                return Reviews.Count == 0 
                    ? 0
                    : (float)Math.Round(Reviews.Average(r => r.OverallRating), 1);
            }
        }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }

        public Pizzeria() {
            Reviews = new Collection<Review>();
        }

        public Pizzeria(PizzeriaModel model) : this()
        {
            this.Update(model);
        }

        public void Update(PizzeriaModel model)
        {
            PizzeriaId = model.PizzeriaId;
            PizzeriaName = model.PizzeriaName;
            YearOpened = model.YearOpened;
            Address = model.Address;
            City = model.City;
            State = model.State;
            ZipCode = model.ZipCode;
            Style = model.Style;
            Description = model.Description;
            Delivery = model.Delivery;
            Takeout = model.Takeout;
            Sitdown = model.Sitdown;
            Alcohol = model.Alcohol;
            PhoneNumber = model.PhoneNumber;
            MenuURL = model.MenuURL;
            OvenType = model.OvenType;
            GlutenFreeOption = model.GlutenFreeOption;
            VeganOption = model.VeganOption;
        }
    }
}
