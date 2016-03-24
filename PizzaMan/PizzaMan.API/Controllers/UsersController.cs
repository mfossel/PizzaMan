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
using AutoMapper;
using PizzaMan.Core.Models;
using PizzaMan.API.Infrastructure;
using PizzaMan.Core.Repository;
using PizzaMan.Core.Infrastructure;

namespace PizzaMan.API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUserRepository userRepository, IUnitOfWork unitOfWork) : base(userRepository)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Users
        public IEnumerable<UserModel> GetUsers()
        {
            return Mapper.Map<IEnumerable<UserModel>>(_userRepository.GetAll());
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(string id)
        {
            User user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<UserModel>(user));
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(string id, UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            var dbUser = _userRepository.GetById(id);
            dbUser.Update(user);
            _userRepository.Update(dbUser);

            try
            {
                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbUser = new User(user);
            _userRepository.Add(dbUser);
            _unitOfWork.Commit();
            user.Id = dbUser.Id;


            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(string id)
        {
            User user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            _userRepository.Delete(user);
            _unitOfWork.Commit();

            return Ok(Mapper.Map<UserModel>(user));
        }
      

        private bool UserExists(string id)
        {
            return _userRepository.Any(e => e.Id == id);
        }

        //Admin query functions

        // GET: api/Users/MostReviews
        [Route("api/users/mostreviews")]
        public IEnumerable<UserModel> GetUsersMostReviews()
        {
            var mostReviews = _userRepository.GetAll().OrderByDescending(u => u.NumberOfReviews).Take(5);
            return Mapper.Map<IEnumerable<UserModel>>(mostReviews);
        }

        // GET: api/Users/MostPhotos
        [Route("api/users/mostphotos")]
        public IEnumerable<UserModel> GetUsersMostPhotos()
        {
            var mostPhotos = _userRepository.GetAll().OrderByDescending(u => u.NumberOfPhotos).Take(5);
            return Mapper.Map<IEnumerable<UserModel>>(mostPhotos);
        }






        //Get: Count
        [Route("api/users/count")]
        public int GetUsersCount()
        {

            return _userRepository.Count();
        }

    }
}