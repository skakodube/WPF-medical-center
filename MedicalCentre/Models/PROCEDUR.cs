namespace MedicalCentre.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PROCEDUR")]
    public partial class PROCEDUR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROCEDUR()
        {
            REQPROCEDUREs = new HashSet<REQPROCEDURE>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDPR { get; set; }

        [StringLength(14)]
        public string NAME { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? COST { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REQPROCEDURE> REQPROCEDUREs { get; set; }
    }
}
