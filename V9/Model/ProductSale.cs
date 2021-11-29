namespace V9.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductSale")]
    public partial class ProductSale
    {
        public int AgentID { get; set; }

        [Key]
        [StringLength(255)]
        public string ProductID { get; set; }

        [Column(TypeName = "date")]
        public DateTime SaleDate { get; set; }

        public int ProductCount { get; set; }

        public virtual Agent Agent { get; set; }

        public virtual Product Product { get; set; }
    }
}
