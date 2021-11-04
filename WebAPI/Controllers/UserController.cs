using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        string path = "data/user.json";
        [HttpGet]
        public IEnumerable<User> Get()
        {
            var users = new List<User>();
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                users = JsonConvert.DeserializeObject<List<User>>(json);
            }
            return users;
        }

        [HttpGet("{ID}")]
        public IActionResult GetUserById(int ID)
        {

            var users = new List<User>();
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                users = JsonConvert.DeserializeObject<List<User>>(json);
            }

            foreach (var user in users)
            {
                System.IO.File.ReadAllText(path);
                if (user.ID == ID)
                {  //string json2 = JsonConvert.SerializeObject(users, Formatting.Indented);

                    return Ok(user);
                }

            }
            return NotFound();
        }
        [HttpPost]
        public async Task<User> PostAsync(User newUser) //Not 
        {
            var users = new List<User>();

            using (StreamReader r = new StreamReader(path))
            {
                string jsonRead = r.ReadToEnd();
                users = JsonConvert.DeserializeObject<List<User>>(jsonRead);
            }
            users.Add(new User());
            string json1 = JsonConvert.SerializeObject(users.ToArray(), Formatting.Indented); //json read new user
            System.IO.File.WriteAllText(path, json1);//json file was created
            users.Add(newUser);
          
            return newUser;
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int ID)

        {
            var users = new List<User>();
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                users = JsonConvert.DeserializeObject<List<User>>(json);
            }
            foreach (var user in users)
            {
                if (user.ID == ID)
                {
                    users.Remove(user);
                    string json2 = JsonConvert.SerializeObject(users, Formatting.Indented);
                    await System.IO.File.WriteAllTextAsync(path, json2);

                }
            }
            return NotFound();
        }
    }
}
