﻿using AutoMapper;
using PizzaMan.API.Infrastructure;
using PizzaMan.Core.Infrastructure;
using PizzaMan.Core.Models;
using PizzaMan.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace PizzaMan.API.Controllers
{
    public class AccountsController : BaseApiController
    {
        private readonly IAuthorizationRepository _authRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountsController(IAuthorizationRepository authRepository, IUserRepository wingmanUserRepository, IUnitOfWork unitOfWork) : base(wingmanUserRepository)
        {
            _authRepository = authRepository;
            _unitOfWork = unitOfWork;

        }

        [AllowAnonymous]
        [Route("api/accounts/register")]
        public async Task<IHttpActionResult> Register(RegistrationModel registration)
        {
            //Server Side Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Pass the Registration onto AuthRepository
            var result = await _authRepository.RegisterUser(registration);

            //Check to see the Registration was Successful
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Registration form was invalid.");
            }
        }

        [Route("api/accounts/currentuser")]
        [HttpGet]
        [ResponseType(typeof(UserModel.Profile))]
        public IHttpActionResult GetCurrentUser()
        {
            return Ok(Mapper.Map<UserModel.Profile>(CurrentUser));
        }

        [Route("api/accounts/currentuser")]
        [HttpPut]
        public IHttpActionResult UpdateCurrentUser(string id, UserModel.Profile user)
        {
            // check to see that id == user.Id

            // check to see that user.Id == CurrentUser.Id

            // update the user

            // call repository.update

            // call unitofwork.commit

            return StatusCode(HttpStatusCode.NoContent);
        }
      
    }
}