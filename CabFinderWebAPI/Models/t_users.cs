using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CabFinderWebAPI.Models
{
    public class t_users
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        //public virtual string password_salt { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public bool available { get; set; }
        public int phonenumber { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public bool active { get; set; } 
    }
}