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
using PizzaMan.API.Infrastructure;
using AutoMapper;
using PizzaMan.Core.Models;

namespace PizzaMan.API.Controllers
{
    public class AspectsController : BaseApiController
    {
        private readonly IAspectRepository _aspectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AspectsController(IAspectRepository aspectRepository, IUnitOfWork unitOfWork, IUserRepository userRepository) : base(userRepository)
        {
            _aspectRepository = aspectRepository;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Aspects
        public IEnumerable<AspectModel> GetAspects()
        {
            return Mapper.Map<IEnumerable<AspectModel>>(_aspectRepository.GetAll());
        }

        // GET: api/Aspects/5
        [ResponseType(typeof(Aspect))]
        public IHttpActionResult GetAspect(int id)
        {
            Aspect aspect = _aspectRepository.GetById(id);
            if (aspect == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<AspectModel>(aspect));
        }

        // PUT: api/Aspects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAspect(int id, AspectModel aspect)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aspect.AspectId)
            {
                return BadRequest();
            }

            var dbAspect = _aspectRepository.GetById(id);
            dbAspect.Update(aspect);
            _aspectRepository.Update(dbAspect);

            try
            {
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                if (!AspectExists(id))
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

        // POST: api/Aspects
        [ResponseType(typeof(Aspect))]
        public IHttpActionResult PostAspect(AspectModel aspect)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbAspect = new Aspect(aspect);
            _aspectRepository.Add(dbAspect);
            _unitOfWork.Commit();
            aspect.AspectId = dbAspect.AspectId;


            return CreatedAtRoute("DefaultApi", new { id = aspect.AspectId }, aspect);
        }

        // DELETE: api/Aspects/5
        [ResponseType(typeof(Aspect))]
        public IHttpActionResult DeleteAspect(int id)
        {
            Aspect aspect = _aspectRepository.GetById(id);
            if (aspect == null)
            {
                return NotFound();
            }

            _aspectRepository.Delete(aspect);
            _unitOfWork.Commit();

            return Ok(Mapper.Map<AspectModel>(aspect));
        }

    

        private bool AspectExists(int id)
        {
            return _aspectRepository.Any(e => e.AspectId == id);
        }
    }
}