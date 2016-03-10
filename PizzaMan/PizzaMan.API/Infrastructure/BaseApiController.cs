﻿using PizzaMan.Core.Domain;
using PizzaMan.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PizzaMan.API.Infrastructure
{
    public class BaseApiController : ApiController
    {
        protected readonly IUserRepository _wingmanUserRepository;

        public BaseApiController(IUserRepository wingmanUserRepository)
        {
            _wingmanUserRepository = wingmanUserRepository;
        }

        protected User CurrentUser
        {
            get
            {
                return _wingmanUserRepository.GetFirstOrDefault(u => u.UserName == User.Identity.Name);
            }
        }
    }
}