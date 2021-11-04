using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Linq;

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
        // [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<User> CreateNewUserIfDBEmpty(User newUser)
        {
            var users = new List<User>();
            using (StreamReader r = new StreamReader(path))
            {
                string jsonRead = r.ReadToEnd();
                users = JsonConvert.DeserializeObject<List<User>>(jsonRead);
            }
            users.Add(newUser);
            string json = JsonConvert.SerializeObject(users.ToArray(), Formatting.Indented); //json read new user

            System.IO.File.WriteAllText(path, json);//json file was created

            return newUser;
        }

        [HttpDelete("{ID}")]
        public async Task<User> DeleteUser(int ID)

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

                    bool isSuccsesfull = users.Remove(user);
                    string json2 = JsonConvert.SerializeObject(users, Formatting.Indented);
                    await System.IO.File.WriteAllTextAsync(path, json2);
                    return user;
                }

            }

            return null;
        }
    }
}
