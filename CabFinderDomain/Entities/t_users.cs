using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabFinderDomain.Entities
{
    public class t_users: IEntity
    {
        public virtual int id { get; set; }
        public virtual string name { get; set; }
        public virtual string password { get; set; }
        //public virtual string password_salt { get; set; }
        public virtual DateTime created_at { get; set; }
        public virtual DateTime updated_at { get; set; }
        public virtual bool available { get; set; }
        public virtual int phonenumber { get; set; }
        public virtual double latitude { get; set; }
        public virtual double longitude { get; set; }
        public virtual bool active { get; set; } 
       
    }
}
