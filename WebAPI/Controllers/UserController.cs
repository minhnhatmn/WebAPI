using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.EF;
using WebAPI.Model;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private DB_NHANTINContext _db;
        public UserController(DB_NHANTINContext context)
        {
            _db = context;
        }
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var user = _db.Users.ToList();
            return Ok(user);
        }
        [Route("GetUser/{id}")]
        [HttpGet]
        public IActionResult GetUser(int id)
        {
            var user = _db.Users.Find(id);
            if (user == null)
            {
                return BadRequest("No user was found");
            }
            return Ok(user);
        }
        [Route("Register")]
        [HttpPost]
        public IActionResult Register(UserModel userModel)
        {
            int id = 0;
            bool check = false;
            do
            {
                Random rnd = new Random();
                id = int.Parse(DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + rnd.Next(0, 1000));
                var userf = _db.Users.Find(id);
                if (userf==null)
                {
                    check = true;
                }
            } while (check==false);
            User user = new User();
            user.IdUser = id;
            user.Username = userModel.Username;
            user.Password = userModel.Password;
            _db.Users.Add(user);
            _db.SaveChanges();
            return Ok(user);
        }
        [Route("Login")]
        [HttpPost]
        public IActionResult Login(UserModel userModel)
        {
            var user = _db.Users.Where(t => t.Username == userModel.Username && t.Password == userModel.Password).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("No user was found");
            }
            return Ok(user);
        }
    }
}
