namespace admin_lovelypa_in
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MPA_CURRENT_SEMESTER
    {
        public int id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal reg_id { get; set; }

        [Required]
        [StringLength(6)]
        public string subject_code { get; set; }

        [Required]
        public string subject_name { get; set; }

        [Column(TypeName = "date")]
        public DateTime last_updated { get; set; }

        public int total_class { get; set; }

        public int duty_leave { get; set; }

        public int present { get; set; }

        public virtual MPA_USER_DATA MPA_USER_DATA { get; set; }
    }
}
