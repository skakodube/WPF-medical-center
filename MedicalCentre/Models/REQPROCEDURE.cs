namespace MedicalCentre.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("REQPROCEDURE")]
    public partial class REQPROCEDURE
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDRPR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal VISIT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PROCEDUR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? QUANTITY { get; set; }

        public virtual PROCEDUR PROCEDUR1 { get; set; }

        public virtual VISIT VISIT1 { get; set; }
    }
}
