using System;
using System.Collections.Generic;

namespace Demo130423.Models
{
    public partial class Orders
    {
        public Orders()
        {
            Orderproduct = new HashSet<Orderproduct>();
        }

        public DateTime DateOrder { get; set; }
        public int? OrderClient { get; set; }
        public int OrderCode { get; set; }
        public DateTime OrderDeliveryDate { get; set; }
        public int OrderId { get; set; }
        public int OrderPickupPoint { get; set; }
        public string OrderStatus { get; set; }

        public virtual User OrderClientNavigation { get; set; }
        public virtual ICollection<Orderproduct> Orderproduct { get; set; }
    }
}
