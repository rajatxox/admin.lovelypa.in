namespace admin_lovelypa_in
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MPA_USER_DATA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MPA_USER_DATA()
        {
            MPA_CGPA_ATTENDANCE = new HashSet<MPA_CGPA_ATTENDANCE>();
            MPA_CURRENT_SEMESTER = new HashSet<MPA_CURRENT_SEMESTER>();
            MPA_MY_EXPENSES = new HashSet<MPA_MY_EXPENSES>();
            MPA_TIME_TABLE = new HashSet<MPA_TIME_TABLE>();
            MPA_USER_DIET_PLAN = new HashSet<MPA_USER_DIET_PLAN>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal user_id { get; set; }

        [Required]
        [StringLength(50)]
        public string user_name { get; set; }

        [Required]
        [StringLength(10)]
        public string date_of_birth { get; set; }

        [Required]
        [StringLength(50)]
        public string email_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal phone_number { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [Required]
        [StringLength(50)]
        public string security_question { get; set; }

        [Required]
        [StringLength(50)]
        public string security_answer { get; set; }

        public string profile_pic { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? height { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? weight { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MPA_CGPA_ATTENDANCE> MPA_CGPA_ATTENDANCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MPA_CURRENT_SEMESTER> MPA_CURRENT_SEMESTER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MPA_MY_EXPENSES> MPA_MY_EXPENSES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MPA_TIME_TABLE> MPA_TIME_TABLE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MPA_USER_DIET_PLAN> MPA_USER_DIET_PLAN { get; set; }
    }
}
