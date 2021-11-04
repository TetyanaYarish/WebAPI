using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using WebAPI.Controllers;

namespace WebAPI.Controllers
{
    public class User
    {
        // public Guid ID { get; set; }
       public int ID { get ; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public int Age { get; set; }
        private static int m_Counter = 10000;
        public User()
        {
            this.ID = System.Threading.Interlocked.Increment(ref m_Counter);
            //IDCounter();
            //this.ID = IDCounter()+1;

        }
        string path = "data/user.json";
       
        //public int IDCounter()
        //{
        //    int u = 0;
        //    var users = new List<User>();
        //    using (StreamReader r = new StreamReader(path))
        //    {
               
        //        string json = r.ReadToEnd();
        //        var u1 = users.Count;
        //        users = JsonConvert.DeserializeObject<List<User>>(json);
        //        int u=users.Count;
        //    }
        //    return u;
        //}
    }
}