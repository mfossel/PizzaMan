using PizzaMan.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMan.Core.Domain
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public string UserId { get; set; }
        public int PizzeriaId { get; set; }
        public string PhotoURL { get; set; }

        public Pizzeria Pizzeria { get; set; }
        public User User { get; set; }

        public Photo() { }

        public Photo(PhotoModel model)
        {
            this.Update(model);
        }

        public void Update(PhotoModel model)
        {
            PhotoId = model.PhotoId;
            UserId = model.UserId;
            PizzeriaId = model.PizzeriaId;
            PhotoURL = model.PhotoURL;
        }
    }
}
