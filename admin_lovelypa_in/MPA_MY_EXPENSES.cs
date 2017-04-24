namespace admin_lovelypa_in
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MPA_MY_EXPENSES
    {
        public int id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal user_id { get; set; }

        [Required]
        [StringLength(50)]
        public string item_name { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }

        public TimeSpan time { get; set; }

        [Column(TypeName = "numeric")]
        public decimal price { get; set; }

        public virtual MPA_USER_DATA MPA_USER_DATA { get; set; }
    }
}
