﻿using System;
using System.Collections.Generic;

namespace Demo130423.Models
{
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
