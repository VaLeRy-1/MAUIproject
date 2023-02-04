using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Configuration;

namespace DAL.EF
{
    public class FitnessContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PersonalInfo> Personalinfos { get; set; }
        public DbSet<PersonalActivity> Personalactivities { get; set; }
        public DbSet<BodyParameters> Bodyparameters { get; set; }
        public DbSet<DifficultyLevel> DifficultyLevels { get; set; }
        public DbSet<Exercises> Exercises { get; set; }
        public DbSet<ExercisesList> ExerciseLists { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingList> TrainingsLists { get; set; }
        public DbSet<PersonalActivitiesList> ActivitiesLists { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConfigurationManager.ConnectionStrings["PostgreSQL"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<User>(UserConfigure);
            modelBuilder.Entity<PersonalInfo>(PersonalInfoConfigure);
            modelBuilder.Entity<PersonalActivity>(PersonalActivityConfigure);
            modelBuilder.Entity<BodyParameters>(BodyParametersConfigure);
            modelBuilder.Entity<DifficultyLevel>(DifficultyConfigure);
            modelBuilder.Entity<Exercises>(ExercisesConfigure);
            modelBuilder.Entity<Training>(TrainingConfigure);
            modelBuilder.Entity<PersonalActivitiesList>(PersonalActivitiesListConfigure);
            modelBuilder.Entity<ExercisesList>(ExercicesListConfigure);
            modelBuilder.Entity<TrainingList>(TrainingListConfigure);
        }

        public void UserConfigure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.id);
            builder.Property(u => u.name).HasColumnName("firstname").HasMaxLength(30);
            builder.Property(u => u.infoId).HasColumnName("personalinfo");
            builder.Property(u => u.activityListId).HasColumnName("personalactivitiesList");
            builder.Property(u => u.bodyId).HasColumnName("bodyparam");
            builder.Property(u => u.trainingListId).HasColumnName("trainingList");
        }

        public void PersonalInfoConfigure(EntityTypeBuilder<PersonalInfo> builder)
        {
            builder.ToTable("PersonalInfo");
            builder.HasKey(i => i.id);
            builder.Property(i => i.id).HasColumnName("idpersinf");
            builder.Property(i => i.email).HasMaxLength(30);
            builder.Property(i => i.phoneNumber).HasColumnName("phonenum").HasMaxLength(30);
            builder.HasOne(i => i.User).WithOne(u => u.personalInfo).HasForeignKey<User>(u => u.infoId);
        }

        public void PersonalActivityConfigure(EntityTypeBuilder<PersonalActivity> builder)
        {
            builder.ToTable("Personalactivities");
            builder.HasKey(a => a.id);
            builder.Property(a => a.id).HasColumnName("idpersact");
        }

        public void BodyParametersConfigure(EntityTypeBuilder<BodyParameters> builder)
        {
            builder.ToTable("BodyParameters");
            builder.HasKey(b => b.id);
            builder.Property(b => b.id).HasColumnName("idbodypar");
            builder.HasOne(b => b.User).WithOne(u => u.bodyParameters).HasForeignKey<User>(u => u.bodyId);
        }

        public void DifficultyConfigure(EntityTypeBuilder<DifficultyLevel> builder)
        {
            builder.ToTable("difficultylevel");
            builder.HasKey(d => d.id);
        }

        public void ExercisesConfigure(EntityTypeBuilder<Exercises> builder)
        {
            builder.ToTable("exercises");
            builder.HasKey(e => e.id);
        }

        public void TrainingConfigure(EntityTypeBuilder<Training> builder)
        {
            builder.ToTable("training");
            builder.HasKey(t => t.id);
            builder.Property(t => t.exerciseListId).HasColumnName("exercisesList");
            builder.Property(t => t.difficultyLevelId).HasColumnName("difficultyLevel");
            builder.Property(t => t.trainingListId).HasColumnName("trainingList");
        }

        public void PersonalActivitiesListConfigure(EntityTypeBuilder<PersonalActivitiesList> builder)
        {
            builder.ToTable("PersonalActiviesList");
            builder.HasKey(p => p.id);
            builder.Property(p => p.id).HasColumnName("listId");
            builder.HasOne(p => p.User).WithOne(u => u.personalActivityList).HasForeignKey<User>(u => u.activityListId);
        }

        public void ExercicesListConfigure(EntityTypeBuilder<ExercisesList> builder)
        {
            builder.ToTable("exercisesList");
            builder.HasKey(e => e.id);
            builder.Property(e => e.id).HasColumnName("exercisesListId");
        }

        public void TrainingListConfigure(EntityTypeBuilder<TrainingList> builder)
        {
            builder.ToTable("trainingList");
            builder.HasKey(t => t.id);
            builder.Property(t => t.id).HasColumnName("trainingListId");
        }
    }
}