using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectManager.Entities.Models;

namespace ProjectManager.Entities.Context
{
    public partial class ProjectManagerContext : DbContext
    {
        private readonly string _connectionString;

        public ProjectManagerContext() { }

        public ProjectManagerContext(DbContextOptions<ProjectManagerContext> options,
            IConfiguration config)
            : base(options)
        {
            _connectionString = config["ProjectManagerContextDb"];
        }

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Para gerar novas migrations comentar a linha 28 e descomentar a 29
                optionsBuilder.UseNpgsql(_connectionString);
                // optionsBuilder.UseNpgsql("Host=35.247.221.10;Port=5432;Database=projectmanager;Username=postgres;Password=Labzwv20@");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("project");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(250);

                entity.Property(e => e.InitialDate)
                    .IsRequired()
                    .HasColumnName("initial_date");

                entity.Property(e => e.FinalDate)
                    .IsRequired()
                    .HasColumnName("final_date");

                entity.Property(e => e.PercentComplete)
                    .HasColumnName("percent_complete");

                entity.Property(e => e.Late)
                    .IsRequired()
                    .HasColumnName("late");

                entity.Property(e => e.Removed)
                    .HasColumnName("removed")
                    .HasDefaultValueSql("false");
            });

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.ToTable("activity");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(250);

                entity.Property(e => e.InitialDate)
                    .IsRequired()
                    .HasColumnName("initial_date");

                entity.Property(e => e.FinalDate)
                    .IsRequired()
                    .HasColumnName("final_date");

                entity.Property(e => e.Finished)
                    .HasColumnName("finished")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Running)
                    .HasColumnName("running")
                    .HasDefaultValueSql("false");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("project_activity_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}