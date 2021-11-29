namespace V9.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductCostHistory")]
    public partial class ProductCostHistory
    {
        [Key]
        [StringLength(255)]
        public string ProductID { get; set; }

        public DateTime ChangeDate { get; set; }

        public decimal CostValue { get; set; }

        public virtual Product Product { get; set; }
    }
}
