using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CabFinderWebAPI.Models
{
    public class User
    {
        public long id { get; set; }
        public string name { get; set; }
        public string password_hash { get; set; }
        public string password_salt { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public bool available { get; set; }
        public int number1 { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public bool active { get; set; }

        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string EMail { get; set; }
        //public string PasswordHash { get; set; }
        //public string PasswordSalt { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
        //public bool Available { get; set; }
        //public string PhoneNumber1 { get; set; }
        //public string PhoneNumber2 { get; set; }
        //public double Latitude { get; set; }
        //public double Longitude { get; set; }
        //public bool StillWorking { get; set; } //Activo
    }
}