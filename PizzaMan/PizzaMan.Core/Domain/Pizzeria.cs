using PizzaMan.Core.Models;
using System;
using System.Collections.Generic;
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
        public int ZipCode { get; set; }
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

        public ICollection<Review> Reviews { get; set; }
        public ICollection<Photo> Photos { get; set; }

        public Pizzeria() { }

        public Pizzeria(PizzeriaModel model)
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
