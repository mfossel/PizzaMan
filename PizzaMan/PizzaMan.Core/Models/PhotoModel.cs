using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMan.Core.Models
{
    public class PhotoModel
    {
        public int PhotoId { get; set; }
        public string UserId { get; set; }
        public int PizzeriaId { get; set; }
        public string PhotoURL { get; set; }

    }
}
