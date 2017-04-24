namespace admin_lovelypa_in
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MPA_TERMS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MPA_TERMS()
        {
            MPA_TERM_DATA = new HashSet<MPA_TERM_DATA>();
        }

        public int id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal user_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal term_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal cgpa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MPA_TERM_DATA> MPA_TERM_DATA { get; set; }
    }
}
