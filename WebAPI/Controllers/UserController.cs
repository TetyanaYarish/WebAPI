using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        [HttpGet]
        public IEnumerable<User> Get()
        {
            var items = new List<User>();
            using (StreamReader r = new StreamReader("data/user.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<User>>(json);
            }
            return items;
        }

        [HttpGet("{ID}")]
      
       // public IActionResult GetUserById ([ FromQueryAttribute ]  int ID)
        public IActionResult GetUserById (int ID)
        {
            var users = new List<User>();
            using (StreamReader r = new StreamReader("data/user.json"))
            {
                string json = r.ReadToEnd();
                users = JsonConvert.DeserializeObject<List<User>>(json);
            }
            foreach (var user in users)
            {
                if (user.ID==ID)
                {
                    return Ok(user);
                }
            }
            return NotFound();
        }
    }
}
