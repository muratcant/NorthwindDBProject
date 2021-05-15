using System;
using System.Collections.Generic;

#nullable disable

namespace NorthwindDBProject.Entities.Entities
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public short ProductId { get; set; }
        public string ProductName { get; set; }
        public short? SupplierId { get; set; }
        public short? CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public float? UnitPrice { get; set; }
        public short? UnitsinStock { get; set; }
        public short? UnitsonOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public int Discontinued { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
