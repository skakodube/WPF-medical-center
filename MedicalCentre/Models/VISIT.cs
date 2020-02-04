namespace MedicalCentre.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VISIT")]
    public partial class VISIT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VISIT()
        {
            REQMEDICATIONs = new HashSet<REQMEDICATION>();
            REQPROCEDUREs = new HashSet<REQPROCEDURE>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal DOCTOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PATIENT { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DATEOFVISIT { get; set; }

        public virtual DOCTOR DOCTOR1 { get; set; }

        public virtual PATIENT PATIENT1 { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REQMEDICATION> REQMEDICATIONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REQPROCEDURE> REQPROCEDUREs { get; set; }

    }
}
