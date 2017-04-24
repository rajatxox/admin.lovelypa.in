namespace admin_lovelypa_in
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MPA_AI_QUESTIONS
    {
        public int id { get; set; }

        [Required]
        public string question { get; set; }

        [Required]
        [StringLength(50)]
        public string command { get; set; }

        public int priority { get; set; }
    }
}
