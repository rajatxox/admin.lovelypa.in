namespace admin_lovelypa_in
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MPA_SECRET_QUESTION
    {
        public int Id { get; set; }

        [Required]
        public string Question { get; set; }
    }
}
