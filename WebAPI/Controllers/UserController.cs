using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        List<User> nUser = new List<User>();

        [HttpGet]
        public IEnumerable<User> Get()
        {

            using (StreamReader r = new StreamReader("data/user.json"))
            {
                string json = r.ReadToEnd();
                nUser = JsonConvert.DeserializeObject<List<User>>(json);
            }
            return nUser;
        }

        [HttpGet("{ID}")]

        // public IActionResult GetUserById ([ FromQueryAttribute ]  int ID)
        public IActionResult GetUserById(int ID)
        {

            using (StreamReader r = new StreamReader("data/user.json"))
            {
                string json = r.ReadToEnd();
                nUser = JsonConvert.DeserializeObject<List<User>>(json);
            }
            foreach (var user in nUser)
            {
                if (user.ID == ID)
                {
                    return Ok(user);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<User> PostAsync(User newUser) //Not 
        {
            //using (StringReader r = new StringReader("data/newUser.json"))
            //{
            //    string json = r.ReadToEnd();
            //    nUser = JsonConvert.DeserializeObject<List<User>>(json);
            //}
            //foreach (var user in nUser)
            //{
               

                nUser.Add(new User()
                {
                    ID = newUser.ID,
                    Name = newUser.Name,
                    FamilyName = newUser.FamilyName,
                    Age = newUser.Age
                });
                string json = JsonConvert.SerializeObject(nUser.ToArray());
                //string jsonData = JsonConvert.SerializeObject(json, Formatting.None);
              System.IO.File.WriteAllText(@"C:\Users\User\Desktop\Work\Week 20\WebAPI\WebAPI\data\newUsers.json", json);
            return newUser;
        }
          
           
        }
    }
