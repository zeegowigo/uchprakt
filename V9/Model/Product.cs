namespace V9.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            ProductMaterial = new HashSet<ProductMaterial>();
        }

        [Key]
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(255)]
        public string ProductTypeID { get; set; }

        [Required]
        [StringLength(10)]
        public string ArticleNumber { get; set; }

        public string Description { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        public int? ProductionPersonCount { get; set; }

        public int? ProductionWorkshopNumber { get; set; }

        public decimal MinCostForAgent { get; set; }

        public virtual ProductType ProductType { get; set; }

        public virtual ProductCostHistory ProductCostHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductMaterial> ProductMaterial { get; set; }

        public virtual ProductSale ProductSale { get; set; }
    }
}
