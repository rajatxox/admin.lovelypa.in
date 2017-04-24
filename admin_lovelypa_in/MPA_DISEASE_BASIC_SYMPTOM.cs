namespace admin_lovelypa_in
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MPA_DISEASE_BASIC_SYMPTOM
    {
        public int id { get; set; }

        public int disease_id { get; set; }

        public int basic_symptom_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal percentage { get; set; }

        public virtual MPA_BASIC_SYMPTOM MPA_BASIC_SYMPTOM { get; set; }

        public virtual MPA_DISEASE MPA_DISEASE { get; set; }
    }
}
