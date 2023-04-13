using System;
using System.Collections.Generic;

namespace Demo130423.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Product = new HashSet<Product>();
        }

        public string Name { get; set; }
        public int Supplierid { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
