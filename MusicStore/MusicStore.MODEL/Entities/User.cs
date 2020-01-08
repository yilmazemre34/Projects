using MusicStore.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.MODEL.Entities
{
    public class User:BaseEntity
    {
        public User()
        {
            Orders = new HashSet<Order>();
            IsActive = false;
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
        public Guid ActivationCode { get; set; }

        //Mapping
        public virtual ICollection<Order> Orders { get; set; }


    }
}
