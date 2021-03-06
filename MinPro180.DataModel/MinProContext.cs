namespace MinPro180.DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MinProContext : DbContext
    {
        public MinProContext()
            : base("name=MinProContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<t_assignment> t_assignment { get; set; }
        public virtual DbSet<t_audit_log> t_audit_log { get; set; }
        public virtual DbSet<t_batch> t_batch { get; set; }
        public virtual DbSet<t_biodata> t_biodata { get; set; }
        public virtual DbSet<t_bootcamp_test_type> t_bootcamp_test_type { get; set; }
        public virtual DbSet<t_bootcamp_type> t_bootcamp_type { get; set; }
        public virtual DbSet<t_category> t_category { get; set; }
        public virtual DbSet<t_clazz> t_clazz { get; set; }
        public virtual DbSet<t_feedback> t_feedback { get; set; }
        public virtual DbSet<t_idle_news> t_idle_news { get; set; }
        public virtual DbSet<t_menu> t_menu { get; set; }
        public virtual DbSet<t_menu_access> t_menu_access { get; set; }
        public virtual DbSet<t_monitoring> t_monitoring { get; set; }
        public virtual DbSet<t_office> t_office { get; set; }
        public virtual DbSet<t_question> t_question { get; set; }
        public virtual DbSet<t_role> t_role { get; set; }
        public virtual DbSet<t_room> t_room { get; set; }
        public virtual DbSet<t_technology> t_technology { get; set; }
        public virtual DbSet<t_technology_trainer> t_technology_trainer { get; set; }
        public virtual DbSet<t_test> t_test { get; set; }
        public virtual DbSet<t_testimony> t_testimony { get; set; }
        public virtual DbSet<t_trainer> t_trainer { get; set; }
        public virtual DbSet<t_user> t_user { get; set; }
        public virtual DbSet<t_version> t_version { get; set; }
        public virtual DbSet<t_version_detail> t_version_detail { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<t_assignment>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<t_assignment>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<t_assignment>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<t_audit_log>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<t_audit_log>()
                .Property(e => e.json_insert)
                .IsUnicode(false);

            modelBuilder.Entity<t_audit_log>()
                .Property(e => e.json_before)
                .IsUnicode(false);

            modelBuilder.Entity<t_audit_log>()
                .Property(e => e.json_after)
                .IsUnicode(false);

            modelBuilder.Entity<t_audit_log>()
                .Property(e => e.json_delete)
                .IsUnicode(false);

            modelBuilder.Entity<t_batch>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<t_batch>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<t_batch>()
                .HasMany(e => e.t_clazz)
                .WithRequired(e => e.t_batch)
                .HasForeignKey(e => e.batch_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_biodata>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<t_biodata>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<t_biodata>()
                .Property(e => e.last_education)
                .IsUnicode(false);

            modelBuilder.Entity<t_biodata>()
                .Property(e => e.graduation_year)
                .IsUnicode(false);

            modelBuilder.Entity<t_biodata>()
                .Property(e => e.educational_level)
                .IsUnicode(false);

            modelBuilder.Entity<t_biodata>()
                .Property(e => e.majors)
                .IsUnicode(false);

            modelBuilder.Entity<t_biodata>()
                .Property(e => e.gpa)
                .IsUnicode(false);

            modelBuilder.Entity<t_biodata>()
                .Property(e => e.du)
                .IsUnicode(false);

            modelBuilder.Entity<t_biodata>()
                .Property(e => e.tro)
                .IsUnicode(false);

            modelBuilder.Entity<t_biodata>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<t_biodata>()
                .Property(e => e.interviewer)
                .IsUnicode(false);

            modelBuilder.Entity<t_biodata>()
                .HasMany(e => e.t_assignment)
                .WithRequired(e => e.t_biodata)
                .HasForeignKey(e => e.biodata_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_biodata>()
                .HasMany(e => e.t_clazz)
                .WithRequired(e => e.t_biodata)
                .HasForeignKey(e => e.biodata_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_biodata>()
                .HasMany(e => e.t_monitoring)
                .WithRequired(e => e.t_biodata)
                .HasForeignKey(e => e.biodata_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_bootcamp_test_type>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<t_bootcamp_test_type>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<t_bootcamp_test_type>()
                .HasMany(e => e.t_biodata)
                .WithOptional(e => e.t_bootcamp_test_type)
                .HasForeignKey(e => e.bootcamp_test_type);

            modelBuilder.Entity<t_bootcamp_type>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<t_bootcamp_type>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<t_bootcamp_type>()
                .HasMany(e => e.t_batch)
                .WithOptional(e => e.t_bootcamp_type)
                .HasForeignKey(e => e.bootcamp_type_id);

            modelBuilder.Entity<t_category>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<t_category>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<t_category>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<t_category>()
                .HasMany(e => e.t_idle_news)
                .WithRequired(e => e.t_category)
                .HasForeignKey(e => e.category_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_feedback>()
                .Property(e => e.json_feedback)
                .IsUnicode(false);

            modelBuilder.Entity<t_idle_news>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<t_idle_news>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<t_menu>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<t_menu>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<t_menu>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<t_menu>()
                .Property(e => e.image_url)
                .IsUnicode(false);

            modelBuilder.Entity<t_menu>()
                .Property(e => e.menu_url)
                .IsUnicode(false);

            modelBuilder.Entity<t_menu>()
                .HasMany(e => e.t_menu_access)
                .WithRequired(e => e.t_menu)
                .HasForeignKey(e => e.menu_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_monitoring>()
                .Property(e => e.last_project)
                .IsUnicode(false);

            modelBuilder.Entity<t_monitoring>()
                .Property(e => e.idle_reason)
                .IsUnicode(false);

            modelBuilder.Entity<t_monitoring>()
                .Property(e => e.placement_at)
                .IsUnicode(false);

            modelBuilder.Entity<t_monitoring>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<t_office>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<t_office>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<t_office>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<t_office>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<t_office>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<t_office>()
                .HasMany(e => e.t_room)
                .WithRequired(e => e.t_office)
                .HasForeignKey(e => e.office_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_question>()
                .Property(e => e.question)
                .IsUnicode(false);

            modelBuilder.Entity<t_question>()
                .HasMany(e => e.t_version_detail)
                .WithRequired(e => e.t_question)
                .HasForeignKey(e => e.question_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_role>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<t_role>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<t_role>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<t_role>()
                .HasMany(e => e.t_menu_access)
                .WithRequired(e => e.t_role)
                .HasForeignKey(e => e.role_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_role>()
                .HasMany(e => e.t_user)
                .WithRequired(e => e.t_role)
                .HasForeignKey(e => e.role_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_room>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<t_room>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<t_room>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<t_room>()
                .HasMany(e => e.t_batch)
                .WithOptional(e => e.t_room)
                .HasForeignKey(e => e.room_id);

            modelBuilder.Entity<t_technology>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<t_technology>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<t_technology>()
                .HasMany(e => e.t_batch)
                .WithRequired(e => e.t_technology)
                .HasForeignKey(e => e.technology_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_technology>()
                .HasMany(e => e.t_technology_trainer)
                .WithRequired(e => e.t_technology)
                .HasForeignKey(e => e.technology_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_test>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<t_test>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<t_test>()
                .HasMany(e => e.t_feedback)
                .WithRequired(e => e.t_test)
                .HasForeignKey(e => e.test_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_testimony>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<t_testimony>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<t_trainer>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<t_trainer>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<t_trainer>()
                .HasMany(e => e.t_batch)
                .WithRequired(e => e.t_trainer)
                .HasForeignKey(e => e.trainer_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_trainer>()
                .HasMany(e => e.t_technology_trainer)
                .WithRequired(e => e.t_trainer)
                .HasForeignKey(e => e.trainer_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<t_version>()
                .HasMany(e => e.t_feedback)
                .WithRequired(e => e.t_version)
                .HasForeignKey(e => e.version_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_version>()
                .HasMany(e => e.t_version_detail)
                .WithRequired(e => e.t_version)
                .HasForeignKey(e => e.version_id)
                .WillCascadeOnDelete(false);
        }
    }
}
