namespace admin_lovelypa_in
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MPA_TERM_DATA
    {
        public int id { get; set; }

        public int term_id { get; set; }

        [Required]
        public string subject_name { get; set; }

        [Required]
        [StringLength(6)]
        public string subject_code { get; set; }

        [Column(TypeName = "numeric")]
        public decimal credit { get; set; }

        [Required]
        [StringLength(2)]
        public string grade { get; set; }

        public virtual MPA_TERMS MPA_TERMS { get; set; }
    }
}
