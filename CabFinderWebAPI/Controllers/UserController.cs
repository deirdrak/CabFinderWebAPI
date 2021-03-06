﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CabFinderDomain;
using CabFinderDomain.Entities;
using NHibernate.Criterion;

namespace CabFinderWebAPI.Controllers
{
    public class UserController : ApiController
    {
        private readonly IRepository _repository;


        public UserController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public bool DriverAuthentication(int phoneNumber,string password)
        {
            var user=_repository.First<t_users>(x=>x.phonenumber==phoneNumber && x.password==password);

            if (user != null)
                return true;
            return false;
        }

        [HttpPost]
        public void UpdateDriversLocation(int phoneNumber, double latitude, double longitude)
        {
            var user = _repository.First<t_users>(x => x.phonenumber == phoneNumber);
            user.latitude = latitude;
            user.longitude = longitude;
            user.updated_at = (DateTime.Now.ToUniversalTime()).AddHours(-6);

            _repository.Update(user);
        }

        [HttpGet]
        public List<t_users> GetAllActiveAvailableUsers()
        {
            return _repository.Query<t_users>(x => x.active && x.available).ToList();
        }
    }
}
