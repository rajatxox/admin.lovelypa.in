namespace admin_lovelypa_in
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MPA_USER_DIET_PLAN
    {
        public int id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal user_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal calories { get; set; }

        [Column(TypeName = "numeric")]
        public decimal carbohydrate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal protein { get; set; }

        [Column(TypeName = "numeric")]
        public decimal cholesterol { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fat { get; set; }

        public virtual MPA_USER_DATA MPA_USER_DATA { get; set; }
    }
}
