namespace V9.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MaterialCountHistory")]
    public partial class MaterialCountHistory
    {
        [Key]
        [StringLength(155)]
        public string MaterialID { get; set; }

        public DateTime ChangeDate { get; set; }

        public double CountValue { get; set; }

        public virtual Material Material { get; set; }
    }
}
