namespace admin_lovelypa_in
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MPA_DIET_CHART
    {
        public int id { get; set; }

        [Required]
        public string item_name { get; set; }

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
    }
}
