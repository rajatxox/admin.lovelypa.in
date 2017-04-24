namespace admin_lovelypa_in
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MPA_CGPA_ATTENDANCE
    {
        public int id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal reg_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal attendance { get; set; }

        [Column(TypeName = "numeric")]
        public decimal cgpa { get; set; }

        public virtual MPA_USER_DATA MPA_USER_DATA { get; set; }
    }
}
