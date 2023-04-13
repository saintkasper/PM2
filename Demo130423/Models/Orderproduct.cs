using System;
using System.Collections.Generic;

namespace Demo130423.Models
{
    public partial class Orderproduct
    {
        public int? Count { get; set; }
        public int OrderId { get; set; }
        public string ProductArticleNumber { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Product ProductArticleNumberNavigation { get; set; }
    }
}
