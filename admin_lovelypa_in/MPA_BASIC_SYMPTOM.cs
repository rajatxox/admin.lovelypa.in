namespace admin_lovelypa_in
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MPA_BASIC_SYMPTOM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MPA_BASIC_SYMPTOM()
        {
            MPA_DETAILED_SYMPTOM = new HashSet<MPA_DETAILED_SYMPTOM>();
            MPA_DISEASE_BASIC_SYMPTOM = new HashSet<MPA_DISEASE_BASIC_SYMPTOM>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string symptom { get; set; }

        public int priority { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MPA_DETAILED_SYMPTOM> MPA_DETAILED_SYMPTOM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MPA_DISEASE_BASIC_SYMPTOM> MPA_DISEASE_BASIC_SYMPTOM { get; set; }
    }
}
