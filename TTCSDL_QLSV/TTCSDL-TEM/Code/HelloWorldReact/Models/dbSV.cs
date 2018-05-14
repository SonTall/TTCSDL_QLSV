namespace HelloWorldReact.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbSV : DbContext
    {
        public dbSV()
            : base("name=TTCSDL")
        {
        }

        public virtual DbSet<batch> batches { get; set; }
        public virtual DbSet<changeclass> changeclasses { get; set; }
        public virtual DbSet<_class> classes { get; set; }
        public virtual DbSet<facility> facilities { get; set; }
        public virtual DbSet<level> levels { get; set; }
        public virtual DbSet<major> majors { get; set; }
        public virtual DbSet<relative> relatives { get; set; }
        public virtual DbSet<student> students { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<batch>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<changeclass>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<changeclass>()
                .Property(e => e.studentcode)
                .IsUnicode(false);

            modelBuilder.Entity<changeclass>()
                .Property(e => e.oldclasscode)
                .IsUnicode(false);

            modelBuilder.Entity<changeclass>()
                .Property(e => e.newclasscode)
                .IsUnicode(false);

            modelBuilder.Entity<_class>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<_class>()
                .Property(e => e.batchcode)
                .IsUnicode(false);

            modelBuilder.Entity<_class>()
                .Property(e => e.levelcode)
                .IsUnicode(false);

            modelBuilder.Entity<_class>()
                .Property(e => e.majorcode)
                .IsUnicode(false);

            modelBuilder.Entity<_class>()
                .HasMany(e => e.changeclasses)
                .WithOptional(e => e._class)
                .HasForeignKey(e => e.newclasscode);

            modelBuilder.Entity<_class>()
                .HasMany(e => e.changeclasses1)
                .WithOptional(e => e.class1)
                .HasForeignKey(e => e.oldclasscode);

            modelBuilder.Entity<facility>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<level>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<major>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<major>()
                .Property(e => e.facilitycode)
                .IsUnicode(false);

            modelBuilder.Entity<relative>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<relative>()
                .Property(e => e.studentcode)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.filecode)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.idcardnumber)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.classcode)
                .IsUnicode(false);
        }
    }
}
