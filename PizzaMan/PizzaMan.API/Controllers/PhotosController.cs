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
using PizzaMan.Core.Models;
using AutoMapper;
using PizzaMan.API.Infrastructure;

namespace PizzaMan.API.Controllers
{
     [Authorize]
    public class PhotosController : BaseApiController
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PhotosController(IPhotoRepository photoRepository, IUnitOfWork unitOfWork, IUserRepository userRepository) : base(userRepository)
        {
            _photoRepository = photoRepository;
            _unitOfWork = unitOfWork;
        }
        // GET: api/Photos
        public IEnumerable<PhotoModel> GetPhotos()
        {
            return Mapper.Map<IEnumerable<PhotoModel>>(_photoRepository.GetAll());
        }

        // GET: api/Photos/5
        [ResponseType(typeof(Photo))]
        public IHttpActionResult GetPhoto(int id)
        {
            Photo photo = _photoRepository.GetById(id);
            if (photo == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<PhotoModel>(photo));
        }

        // PUT: api/Photos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPhoto(int id, PhotoModel photo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != photo.PhotoId)
            {
                return BadRequest();
            }

            var dbPhoto = _photoRepository.GetById(id);
            dbPhoto.Update(photo);
            _photoRepository.Update(dbPhoto);

            try
            {
                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoExists(id))
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

        // POST: api/Photos
        [ResponseType(typeof(Photo))]
        public IHttpActionResult PostPhoto(PhotoModel photo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbPhoto = new Photo(photo);
            _photoRepository.Add(dbPhoto);
            _unitOfWork.Commit();
            photo.PhotoId = dbPhoto.PhotoId;


            return CreatedAtRoute("DefaultApi", new { id = photo.PhotoId }, photo);
        }

        // DELETE: api/Photos/5
        [ResponseType(typeof(Photo))]
        public IHttpActionResult DeletePhoto(int id)
        {
            Photo photo = _photoRepository.GetById(id);

            if (photo == null)
            {
                return NotFound();
            }

            _photoRepository.Delete(photo);
            _unitOfWork.Commit();

            return Ok(Mapper.Map<PhotoModel>(photo));
        }

       

        private bool PhotoExists(int id)
        {
            return _photoRepository.Any(e => e.PhotoId == id);
        }
    }
}