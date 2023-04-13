using System;
using System.Collections.Generic;

namespace Demo130423.Models
{
    public partial class Product
    {
        public Product()
        {
            Orderproduct = new HashSet<Orderproduct>();
        }

        public string ProductArticleNumber { get; set; }
        public int ProductCategory { get; set; }
        public decimal ProductCost { get; set; }
        public string ProductDescription { get; set; }
        public sbyte? ProductDiscountAmount { get; set; }
        public int ProductManufacturer { get; set; }
        public int ProductMaxDiscount { get; set; }
        public string ProductName { get; set; }
        public byte[] ProductPhoto { get; set; }
        public int ProductQuantityInStock { get; set; }
        public string ProductStatus { get; set; }
        public int ProductSupplier { get; set; }
        public int ProductUnit { get; set; }

        public virtual Category ProductCategoryNavigation { get; set; }
        public virtual Manufacturer ProductManufacturerNavigation { get; set; }
        public virtual Supplier ProductSupplierNavigation { get; set; }
        public virtual Unit ProductUnitNavigation { get; set; }
        public virtual ICollection<Orderproduct> Orderproduct { get; set; }
    }
}
