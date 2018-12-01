using CodeAssgnment.Shared;
using CodeAssignment.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace CodeAssignment.Api.Controllers
{
    public class UserController : ApiController
    {
        private UserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        // GET: api/User
        [HttpGet]
        public JsonResult<List<UserEntity>> Get()
        {
            return Json<List<UserEntity>>(_userService.GetAllUsers());
        }

        // GET: api/User/5
        public JsonResult<UserEntity> Get(int id)
        {
            return Json<UserEntity>(_userService.GetUser((int)id));
        }

        // POST: api/User
        public int Post(UserEntity model)
        {
            return _userService.AddUpdateUser(model);
        }

        // PUT: api/User/5
        public int Put(UserEntity model)
        {
            return _userService.AddUpdateUser(model);
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
