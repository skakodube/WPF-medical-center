namespace MedicalCentre.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DOCTOR")]
    public partial class DOCTOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOCTOR()
        {
            VISITs = new HashSet<VISIT>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDD { get; set; }

        [StringLength(10)]
        public string NAME { get; set; }

        [StringLength(15)]
        public string SURNAME { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SAL { get; set; }

        [StringLength(15)]
        public string ADDRESS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PHONENUM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SPECIALIZATION { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HIRE { get; set; }

        [StringLength(15)]
        public string STATUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VISIT> VISITs { get; set; }

        public virtual SPEC SPEC { get; set; }

        public override string ToString()
        {
            return NAME + "\t" + SURNAME +"\t"+SPEC.NAME;
        }
    }
}
