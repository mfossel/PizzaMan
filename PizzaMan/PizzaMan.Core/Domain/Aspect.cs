using PizzaMan.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMan.Core.Domain
{
    public class Aspect
    {
        public int AspectId { get; set; }
        public string Name { get; set; }

        public Aspect() { }

        public Aspect(AspectModel model)
        {
            this.Update(model);
        }

        public void Update(AspectModel model)
        {
            AspectId = model.AspectId;
            Name = model.Name;

        }
    }
}
