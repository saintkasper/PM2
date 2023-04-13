using System;
using System.Collections.Generic;

namespace Demo130423.Models
{
    public partial class Unit
    {
        public Unit()
        {
            Product = new HashSet<Product>();
        }

        public string Name { get; set; }
        public int Unitid { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
