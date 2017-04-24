namespace admin_lovelypa_in
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MPA_TIME_TABLE
    {
        public int id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal reg_id { get; set; }

        [Required]
        [StringLength(50)]
        public string class_type { get; set; }

        public TimeSpan time_from { get; set; }

        public TimeSpan time_to { get; set; }

        public int day { get; set; }

        [Required]
        [StringLength(6)]
        public string subject_code { get; set; }

        [Required]
        [StringLength(6)]
        public string room_number { get; set; }

        public virtual MPA_USER_DATA MPA_USER_DATA { get; set; }
    }
}
