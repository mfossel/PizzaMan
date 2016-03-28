using System;
using System.Collections.Generic;
using System.Data;
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
        //[Authorize]
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
            catch (Exception)
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


        //Pizzeria Custom Functions

        // GET: api/Pizzerias/ZipCode
        [Route("api/pizzerias/zip={zip}")]
        public IEnumerable<PizzeriaModel> GetPizzeriasByZipCode(string zip)
        {
            return Mapper.Map<IEnumerable<PizzeriaModel>>(_pizzeriaRepository.GetWhere(p => p.ZipCode == zip));
        }

        // GET: api/Pizzerias/City
        [Route("api/pizzerias/city={city}")]
        public IEnumerable<PizzeriaModel> GetPizzeriasByCity(string city)
        {
            return Mapper.Map<IEnumerable<PizzeriaModel>>(_pizzeriaRepository.GetWhere(p => p.City == city));
        }

        // GET: api/Pizzerias/Name

        [Route("api/pizzerias/name={name}")]
        public IEnumerable<PizzeriaModel> GetPizzeriasByName(string name)
        {
            return Mapper.Map<IEnumerable<PizzeriaModel>>(_pizzeriaRepository.GetWhere(p => p.PizzeriaName == name));
        }
        


        //Pizzer Data Functions

        // GET: api/Pizzerias/MostReviews
        [Route("api/pizzerias/mostreviews")]
        public IEnumerable<PizzeriaModel> GetPizzeriasMostReviews()
        {

            var mostReviews = _pizzeriaRepository.GetAll().OrderByDescending(r => r.NumberOfReviews).Take(5);
            return Mapper.Map<IEnumerable<PizzeriaModel>>(mostReviews);
        }

        // GET: api/Pizzerias/HighestRated
        [Route("api/pizzerias/highestrated")]
        public IEnumerable<PizzeriaModel> GetPizzeriasHighestRated()
        {

            var highestRated = _pizzeriaRepository.GetAll().OrderByDescending(p => p.AverageRating).Take(5);
            return Mapper.Map<IEnumerable<PizzeriaModel>>(highestRated);
        }

        // GET: api/Pizzerias/Oldest
        [Route("api/pizzerias/oldest")]
        public IEnumerable<PizzeriaModel> GetPizzeriasOldest()
        {

            var oldest = _pizzeriaRepository.GetAll().OrderBy(p => p.YearOpened).Take(5);
            return Mapper.Map<IEnumerable<PizzeriaModel>>(oldest);
        }

        // GET: api/Pizzerias/HighestRatedDelivery
        [Route("api/pizzerias/highestrateddelivery")]
        public IEnumerable<PizzeriaModel> GetPizzeriasHighestRatedDelivery()
        {

            var highestRatedDelivery = _pizzeriaRepository.GetAll().Where(p => p.Delivery == true).
                OrderByDescending(p => p.AverageRating).Take(5);
            return Mapper.Map<IEnumerable<PizzeriaModel>>(highestRatedDelivery);
        }

        // GET: api/Pizzerias/HighestRatedSitodwn
        [Route("api/pizzerias/highestratedsitdown")]
        public IEnumerable<PizzeriaModel> GetPizzeriasHighestRatedSitdown()
        {

            var highestRatedSitdown = _pizzeriaRepository.GetAll().Where(p => p.Sitdown == true).
                OrderByDescending(p => p.AverageRating).Take(5);
            return Mapper.Map<IEnumerable<PizzeriaModel>>(highestRatedSitdown);
        }

        // GET: api/Pizzerias/HighestRatedGlutenFree
        [Route("api/pizzerias/highestratedglutenfree")]
        public IEnumerable<PizzeriaModel> GetPizzeriasHighestRatedGlutenFree()
        {

            var highestRatedGlutenFree= _pizzeriaRepository.GetAll().Where(p => p.GlutenFreeOption == true).
                OrderByDescending(p => p.AverageRating).Take(5);
            return Mapper.Map<IEnumerable<PizzeriaModel>>(highestRatedGlutenFree);
        }

        // GET: api/Pizzerias/AverageNumberOfReviews
        [Route("api/pizzerias/avgnumberofreviews")]
        public double GetAverageNumberPhotos()
        {
            double avg = _pizzeriaRepository.GetAll().Select(u => u.NumberOfReviews).Average();
            return avg;
        }

        // GET: api/Pizzerias/AverageOverallRating
        [Route("api/pizzerias/avgoverallrating")]
        public double GetAverageOverallRating()
        {
            double avg = _pizzeriaRepository.GetAll().Select(u => u.AverageRating).Average();
            return avg;
        }


        // GET: api/Pizzerias/PercentOfferingDelivery
        [Route("api/pizzerias/percentdelivery")]
        public int GetPercentDelivery()
        {
            decimal del = _pizzeriaRepository.GetWhere(p => p.Delivery == true).Count();
            decimal count = _pizzeriaRepository.Count();

            decimal percentDec = del / count;

            int percent = (int)(percentDec * 100);

            return percent;
        }

        // GET: api/Pizzerias/PercentServingAlcohol
        [Route("api/pizzerias/percentalcohol")]
        public int GetPercentAlcohol()
        {
            decimal del = _pizzeriaRepository.GetWhere(p => p.Alcohol == true).Count();
            decimal count = _pizzeriaRepository.Count();

            decimal percentDec = del / count;

            int percent = (int)(percentDec * 100);

            return percent;
        }

        // GET: api/Pizzerias/PercentVegan
        [Route("api/pizzerias/percentvegan")]
        public int GetPercentVegan()
        {
            decimal del = _pizzeriaRepository.GetWhere(p => p.VeganOption == true).Count();
            decimal count = _pizzeriaRepository.Count();

            decimal percentDec = del / count;

            int percent = (int)(percentDec * 100);

            return percent;
        }

        // GET: api/Pizzerias/GlutenFree
        [Route("api/pizzerias/percentglutenfree")]
        public int GetPercentGlutenFree()
        {
            decimal del = _pizzeriaRepository.GetWhere(p => p.GlutenFreeOption == true).Count();
            decimal count = _pizzeriaRepository.Count();

            decimal percentDec = del / count;

            int percent = (int)(percentDec * 100);

            return percent;
        }



        //Get: Count
        [Route("api/pizzerias/count")]
        public int GetPizzeriasCount()
        {

            return _pizzeriaRepository.Count();
        }

    }
}