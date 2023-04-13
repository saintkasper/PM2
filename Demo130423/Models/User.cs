using System;
using System.Collections.Generic;

namespace Demo130423.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Orders>();
        }

        public int UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserPatronymic { get; set; }
        public int UserRole { get; set; }
        public string UserSurname { get; set; }

        public virtual Role UserRoleNavigation { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
