using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PizzaMan.Core.Domain;
using PizzaMan.DATA.Infrastructure;
using PizzaMan.Core.Repository;
using PizzaMan.Core.Infrastructure;
using AutoMapper;
using PizzaMan.Core.Models;
using PizzaMan.API.Infrastructure;

namespace PizzaMan.API.Controllers
{
    
    public class PizzeriasController : BaseApiController
    {
        private readonly IPizzeriaRepository _pizzeriaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PizzeriasController(IPizzeriaRepository pizzeriaRepository, IUnitOfWork unitOfWork, IUserRepository userRepository) : base(userRepository)
        {
            _pizzeriaRepository = pizzeriaRepository;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Pizzerias
        public IEnumerable<PizzeriaModel> GetPizzerias()
        {
            return Mapper.Map<IEnumerable<PizzeriaModel>>(_pizzeriaRepository.GetAll());
        }

        // GET: api/Pizzerias/5
        [ResponseType(typeof(Pizzeria))]
        public IHttpActionResult GetPizzeria(int id)
        {
            Pizzeria pizzeria = _pizzeriaRepository.GetById(id);
            if (pizzeria == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<PizzeriaModel>(pizzeria));
        }

        // PUT: api/Pizzerias/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPizzeria(int id, PizzeriaModel pizzeria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pizzeria.PizzeriaId)
            {
                return BadRequest();
            }

            var dbPizzeria = _pizzeriaRepository.GetById(id);
            dbPizzeria.Update(pizzeria);
            _pizzeriaRepository.Update(dbPizzeria);

            try
            {
                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzeriaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Pizzerias
        [Authorize]
        [ResponseType(typeof(Pizzeria))]
        public IHttpActionResult PostPizzeria(PizzeriaModel pizzeria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbPizzeria = new Pizzeria(pizzeria);
            _pizzeriaRepository.Add(dbPizzeria);
            _unitOfWork.Commit();
            pizzeria.PizzeriaId = dbPizzeria.PizzeriaId;


            return CreatedAtRoute("DefaultApi", new { id = pizzeria.PizzeriaId }, pizzeria);
        }

        // DELETE: api/Pizzerias/5
        [Authorize]
        [ResponseType(typeof(Pizzeria))]
        public IHttpActionResult DeletePizzeria(int id)
        {
            Pizzeria pizzeria = _pizzeriaRepository.GetById(id);
            if (pizzeria == null)
            {
                return NotFound();
            }

            _pizzeriaRepository.Delete(pizzeria);
            _unitOfWork.Commit();

            return Ok(Mapper.Map<PizzeriaModel>(pizzeria));
        }


        private bool PizzeriaExists(int id)
        {
            return _pizzeriaRepository.Any(e => e.PizzeriaId == id);
        }
    }
}