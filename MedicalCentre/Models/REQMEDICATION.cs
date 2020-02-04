namespace MedicalCentre.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("REQMEDICATION")]
    public partial class REQMEDICATION
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDRM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal VISIT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal MEDICATION { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? QUANTITY { get; set; }

        public virtual MEDICATION MEDICATION1 { get; set; }

        public virtual VISIT VISIT1 { get; set; }
    }
}
