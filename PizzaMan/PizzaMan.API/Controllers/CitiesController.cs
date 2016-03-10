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
using PizzaMan.API.Infrastructure;
using PizzaMan.Core.Repository;
using PizzaMan.Core.Infrastructure;
using AutoMapper;
using PizzaMan.Core.Models;

namespace PizzaMan.API.Controllers
{

    [Authorize]
    public class CitiesController : BaseApiController
    {
        private readonly ICityRepository _cityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CitiesController(ICityRepository cityRepository, IUnitOfWork unitOfWork, IUserRepository userRepository) : base(userRepository)
        {
            _cityRepository = cityRepository;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Cities
        public IEnumerable<CityModel> GetCities()
        {        
            return Mapper.Map<IEnumerable<CityModel>>(_cityRepository.GetAll());
        }

        // GET: api/Cities/5
        [ResponseType(typeof(City))]
        public IHttpActionResult GetCity(int id)
        {
            City city = _cityRepository.GetById(id);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<CityModel>(city));
        }

        // PUT: api/Cities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCity(int id, CityModel city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != city.CityId)
            {
                return BadRequest();
            }

            var dbCity = _cityRepository.GetById(id);
            dbCity.Update(city);
            _cityRepository.Update(dbCity);



            try
            {
                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
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

        // POST: api/Cities
        [ResponseType(typeof(City))]
        public IHttpActionResult PostCity(CityModel city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbCity = new City(city);
            _cityRepository.Add(dbCity);
            _unitOfWork.Commit();
            city.CityId = dbCity.CityId;

            return CreatedAtRoute("DefaultApi", new { id = city.CityId }, city);
        }

        // DELETE: api/Cities/5
        [ResponseType(typeof(City))]
        public IHttpActionResult DeleteCity(int id)
        {
            City city = _cityRepository.GetById(id);

            if (city == null)
            {
                return NotFound();
            }

            _cityRepository.Delete(city);
            _unitOfWork.Commit();

            return Ok(Mapper.Map<CityModel>(city));
        }


        private bool CityExists(int id)
        {
            return _cityRepository.Any(e => e.CityId == id);
        }
    }
}