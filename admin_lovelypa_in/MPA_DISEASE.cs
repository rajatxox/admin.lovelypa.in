namespace admin_lovelypa_in
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MPA_DISEASE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MPA_DISEASE()
        {
            MPA_DISEASE_BASIC_SYMPTOM = new HashSet<MPA_DISEASE_BASIC_SYMPTOM>();
            MPA_DISEASE_DETAILED_SYMPTOM = new HashSet<MPA_DISEASE_DETAILED_SYMPTOM>();
        }

        public int id { get; set; }

        [Required]
        public string disease { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MPA_DISEASE_BASIC_SYMPTOM> MPA_DISEASE_BASIC_SYMPTOM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MPA_DISEASE_DETAILED_SYMPTOM> MPA_DISEASE_DETAILED_SYMPTOM { get; set; }
    }
}
