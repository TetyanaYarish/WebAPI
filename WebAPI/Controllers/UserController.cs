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
                {  
                    string json2 = JsonConvert.SerializeObject(users, Formatting.Indented);

                    return Ok(user);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<User> PostAsync(User newUser)
        {

            var users = new List<User>();
            using (StreamReader r = new StreamReader(path))
            {

                string json = JsonConvert.SerializeObject(users, Formatting.Indented);
                string json1 = r.ReadToEnd();
                users = JsonConvert.DeserializeObject<List<User>>(json1);
                if (users == null)
                {
                    await System.IO.File.WriteAllTextAsync(path, json);
                    users.Add(newUser);
                }
                users.Add(newUser);
            }

            string json2 = JsonConvert.SerializeObject(users, Formatting.Indented);
            await System.IO.File.WriteAllTextAsync(path, json2);
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
