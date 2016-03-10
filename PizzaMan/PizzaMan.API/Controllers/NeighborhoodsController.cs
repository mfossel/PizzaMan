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
using PizzaMan.Core.Infrastructure;
using PizzaMan.Core.Repository;
using PizzaMan.Core.Models;
using AutoMapper;
using PizzaMan.API.Infrastructure;

namespace PizzaMan.API.Controllers
{
    [Authorize]
    public class NeighborhoodsController : BaseApiController
    {
        private readonly INeighborhoodRepository _neighborhoodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NeighborhoodsController(INeighborhoodRepository neighborhoodRepository, IUnitOfWork unitOfWork, IUserRepository userRepository) : base(userRepository)
        {
            _neighborhoodRepository = neighborhoodRepository;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Neighborhoods
        public IEnumerable<NeighborhoodModel> GetNeighborhoods()
        {
            return Mapper.Map<IEnumerable<NeighborhoodModel>>(_neighborhoodRepository.GetAll());
        }

        // GET: api/Neighborhoods/5
        [ResponseType(typeof(Neighborhood))]
        public IHttpActionResult GetNeighborhood(int id)
        {
            Neighborhood neighborhood = _neighborhoodRepository.GetById(id);
            if (neighborhood == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<NeighborhoodModel>(neighborhood));
        }

        // PUT: api/Neighborhoods/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNeighborhood(int id, NeighborhoodModel neighborhood)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != neighborhood.NeighborhoodId)
            {
                return BadRequest();
            }

            var dbNeighborhood = _neighborhoodRepository.GetById(id);
            dbNeighborhood.Update(neighborhood);
            _neighborhoodRepository.Update(dbNeighborhood);

            try
            {
                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NeighborhoodExists(id))
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

        // POST: api/Neighborhoods
        [ResponseType(typeof(Neighborhood))]
        public IHttpActionResult PostNeighborhood(NeighborhoodModel neighborhood)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbNeighborhood = new Neighborhood(neighborhood);
            _neighborhoodRepository.Add(dbNeighborhood);
            _unitOfWork.Commit();
            neighborhood.NeighborhoodId = dbNeighborhood.NeighborhoodId;

            return CreatedAtRoute("DefaultApi", new { id = neighborhood.NeighborhoodId }, neighborhood);
        }

        // DELETE: api/Neighborhoods/5
        [ResponseType(typeof(Neighborhood))]
        public IHttpActionResult DeleteNeighborhood(int id)
        {
            Neighborhood neighborhood = _neighborhoodRepository.GetById(id);
            if (neighborhood == null)
            {
                return NotFound();
            }

            _neighborhoodRepository.Delete(neighborhood);
            _unitOfWork.Commit();

            return Ok(Mapper.Map<NeighborhoodModel>(neighborhood));
        }


        private bool NeighborhoodExists(int id)
        {
            return _neighborhoodRepository.Any(e => e.NeighborhoodId == id);
        }
    }
}