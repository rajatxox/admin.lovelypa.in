namespace admin_lovelypa_in
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MPA_DATA : DbContext
    {
        public MPA_DATA()
            : base("name=MPA_DATA")
        {
        }

        public virtual DbSet<MPA_AI_QUESTIONS> MPA_AI_QUESTIONS { get; set; }
        public virtual DbSet<MPA_BASIC_SYMPTOM> MPA_BASIC_SYMPTOM { get; set; }
        public virtual DbSet<MPA_CGPA_ATTENDANCE> MPA_CGPA_ATTENDANCE { get; set; }
        public virtual DbSet<MPA_CURRENT_SEMESTER> MPA_CURRENT_SEMESTER { get; set; }
        public virtual DbSet<MPA_DETAILED_SYMPTOM> MPA_DETAILED_SYMPTOM { get; set; }
        public virtual DbSet<MPA_DIET_CHART> MPA_DIET_CHART { get; set; }
        public virtual DbSet<MPA_DISEASE> MPA_DISEASE { get; set; }
        public virtual DbSet<MPA_DISEASE_BASIC_SYMPTOM> MPA_DISEASE_BASIC_SYMPTOM { get; set; }
        public virtual DbSet<MPA_DISEASE_DETAILED_SYMPTOM> MPA_DISEASE_DETAILED_SYMPTOM { get; set; }
        public virtual DbSet<MPA_MY_EXPENSES> MPA_MY_EXPENSES { get; set; }
        public virtual DbSet<MPA_SECRET_QUESTION> MPA_SECRET_QUESTION { get; set; }
        public virtual DbSet<MPA_TERM_DATA> MPA_TERM_DATA { get; set; }
        public virtual DbSet<MPA_TERMS> MPA_TERMS { get; set; }
        public virtual DbSet<MPA_TIME_TABLE> MPA_TIME_TABLE { get; set; }
        public virtual DbSet<MPA_USER_DATA> MPA_USER_DATA { get; set; }
        public virtual DbSet<MPA_USER_DIET_PLAN> MPA_USER_DIET_PLAN { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MPA_AI_QUESTIONS>()
                .Property(e => e.question)
                .IsUnicode(false);

            modelBuilder.Entity<MPA_AI_QUESTIONS>()
                .Property(e => e.command)
                .IsUnicode(false);

            modelBuilder.Entity<MPA_BASIC_SYMPTOM>()
                .Property(e => e.symptom)
                .IsUnicode(false);

            modelBuilder.Entity<MPA_BASIC_SYMPTOM>()
                .HasMany(e => e.MPA_DETAILED_SYMPTOM)
                .WithRequired(e => e.MPA_BASIC_SYMPTOM)
                .HasForeignKey(e => e.basic_symptom_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MPA_BASIC_SYMPTOM>()
                .HasMany(e => e.MPA_DISEASE_BASIC_SYMPTOM)
                .WithRequired(e => e.MPA_BASIC_SYMPTOM)
                .HasForeignKey(e => e.basic_symptom_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MPA_CGPA_ATTENDANCE>()
                .Property(e => e.reg_id)
                .HasPrecision(8, 0);

            modelBuilder.Entity<MPA_CGPA_ATTENDANCE>()
                .Property(e => e.attendance)
                .HasPrecision(5, 2);

            modelBuilder.Entity<MPA_CGPA_ATTENDANCE>()
                .Property(e => e.cgpa)
                .HasPrecision(5, 2);

            modelBuilder.Entity<MPA_CURRENT_SEMESTER>()
                .Property(e => e.reg_id)
                .HasPrecision(8, 0);

            modelBuilder.Entity<MPA_CURRENT_SEMESTER>()
                .Property(e => e.subject_code)
                .IsUnicode(false);

            modelBuilder.Entity<MPA_CURRENT_SEMESTER>()
                .Property(e => e.subject_name)
                .IsUnicode(false);

            modelBuilder.Entity<MPA_DETAILED_SYMPTOM>()
                .Property(e => e.detailed_symptom)
                .IsUnicode(false);

            modelBuilder.Entity<MPA_DIET_CHART>()
                .Property(e => e.item_name)
                .IsUnicode(false);

            modelBuilder.Entity<MPA_DIET_CHART>()
                .Property(e => e.cholesterol)
                .HasPrecision(18, 5);

            modelBuilder.Entity<MPA_DISEASE>()
                .Property(e => e.disease)
                .IsUnicode(false);

            modelBuilder.Entity<MPA_DISEASE>()
                .HasMany(e => e.MPA_DISEASE_BASIC_SYMPTOM)
                .WithRequired(e => e.MPA_DISEASE)
                .HasForeignKey(e => e.disease_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MPA_DISEASE>()
                .HasMany(e => e.MPA_DISEASE_DETAILED_SYMPTOM)
                .WithRequired(e => e.MPA_DISEASE)
                .HasForeignKey(e => e.disease_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MPA_DISEASE_BASIC_SYMPTOM>()
                .Property(e => e.percentage)
                .HasPrecision(5, 2);

            modelBuilder.Entity<MPA_DISEASE_DETAILED_SYMPTOM>()
                .Property(e => e.percentage)
                .HasPrecision(5, 2);

            modelBuilder.Entity<MPA_MY_EXPENSES>()
                .Property(e => e.user_id)
                .HasPrecision(8, 0);

            modelBuilder.Entity<MPA_MY_EXPENSES>()
                .Property(e => e.item_name)
                .IsUnicode(false);

            modelBuilder.Entity<MPA_MY_EXPENSES>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MPA_SECRET_QUESTION>()
                .Property(e => e.Question)
                .IsUnicode(false);

            modelBuilder.Entity<MPA_TERM_DATA>()
                .Property(e => e.subject_name)
                .IsUnicode(false);

            modelBuilder.Entity<MPA_TERM_DATA>()
                .Property(e => e.subject_code)
                .IsUnicode(false);

            modelBuilder.Entity<MPA_TERM_DATA>()
                .Property(e => e.credit)
                .HasPrecision(4, 2);

            modelBuilder.Entity<MPA_TERM_DATA>()
                .Property(e => e.grade)
                .IsUnicode(false);

            modelBuilder.Entity<MPA_TERMS>()
                .Property(e => e.user_id)
                .HasPrecision(8, 0);

            modelBuilder.Entity<MPA_TERMS>()
                .Property(e => e.term_id)
                .HasPrecision(6, 0);

            modelBuilder.Entity<MPA_TERMS>()
                .Property(e => e.cgpa)
                .HasPrecision(4, 2);

            modelBuilder.Entity<MPA_TERMS>()
                .HasMany(e => e.MPA_TERM_DATA)
                .WithRequired(e => e.MPA_TERMS)
                .HasForeignKey(e => e.term_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MPA_TIME_TABLE>()
                .Property(e => e.reg_id)
                .HasPrecision(8, 0);

            modelBuilder.Entity<MPA_TIME_TABLE>()
                .Property(e => e.class_type)
                .IsUnicode(false);

            modelBuilder.Entity<MPA_TIME_TABLE>()
                .Property(e => e.subject_code)
                .IsUnicode(false);

            modelBuilder.Entity<MPA_TIME_TABLE>()
                .Property(e => e.room_number)
                .IsUnicode(false);

            modelBuilder.Entity<MPA_USER_DATA>()
                .Property(e => e.user_id)
                .HasPrecision(8, 0);

            modelBuilder.Entity<MPA_USER_DATA>()
                .Property(e => e.user_name)
                .IsUnicode(false);

            modelBuilder.Entity<MPA_USER_DATA>()
                .Property(e => e.date_of_birth)
                .IsUnicode(false);

            modelBuilder.Entity<MPA_USER_DATA>()
                .Property(e => e.email_id)
                .IsUnicode(false);

            modelBuilder.Entity<MPA_USER_DATA>()
                .Property(e => e.phone_number)
                .HasPrecision(10, 0);

            modelBuilder.Entity<MPA_USER_DATA>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<MPA_USER_DATA>()
                .Property(e => e.security_question)
                .IsUnicode(false);

            modelBuilder.Entity<MPA_USER_DATA>()
                .Property(e => e.security_answer)
                .IsUnicode(false);

            modelBuilder.Entity<MPA_USER_DATA>()
                .Property(e => e.profile_pic)
                .IsUnicode(false);

            modelBuilder.Entity<MPA_USER_DATA>()
                .Property(e => e.height)
                .HasPrecision(5, 2);

            modelBuilder.Entity<MPA_USER_DATA>()
                .Property(e => e.weight)
                .HasPrecision(5, 2);

            modelBuilder.Entity<MPA_USER_DATA>()
                .HasMany(e => e.MPA_CGPA_ATTENDANCE)
                .WithRequired(e => e.MPA_USER_DATA)
                .HasForeignKey(e => e.reg_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MPA_USER_DATA>()
                .HasMany(e => e.MPA_CURRENT_SEMESTER)
                .WithRequired(e => e.MPA_USER_DATA)
                .HasForeignKey(e => e.reg_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MPA_USER_DATA>()
                .HasMany(e => e.MPA_MY_EXPENSES)
                .WithRequired(e => e.MPA_USER_DATA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MPA_USER_DATA>()
                .HasMany(e => e.MPA_TIME_TABLE)
                .WithRequired(e => e.MPA_USER_DATA)
                .HasForeignKey(e => e.reg_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MPA_USER_DATA>()
                .HasMany(e => e.MPA_USER_DIET_PLAN)
                .WithRequired(e => e.MPA_USER_DATA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MPA_USER_DIET_PLAN>()
                .Property(e => e.user_id)
                .HasPrecision(8, 0);

            modelBuilder.Entity<MPA_USER_DIET_PLAN>()
                .Property(e => e.cholesterol)
                .HasPrecision(18, 5);
        }
    }
}
