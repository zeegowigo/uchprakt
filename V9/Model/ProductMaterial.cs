namespace V9.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductMaterial")]
    public partial class ProductMaterial
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string ProductID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(155)]
        public string MaterialID { get; set; }

        public double? Count { get; set; }

        public virtual Material Material { get; set; }

        public virtual Product Product { get; set; }
    }
}
