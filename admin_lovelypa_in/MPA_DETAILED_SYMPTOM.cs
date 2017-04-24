namespace admin_lovelypa_in
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MPA_DETAILED_SYMPTOM
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int basic_symptom_Id { get; set; }

        [Required]
        public string detailed_symptom { get; set; }

        public int priority { get; set; }

        public virtual MPA_BASIC_SYMPTOM MPA_BASIC_SYMPTOM { get; set; }
    }
}
