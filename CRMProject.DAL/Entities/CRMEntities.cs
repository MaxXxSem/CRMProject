namespace CRMProject.DAL.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CRMEntities : DbContext
    {
        public CRMEntities()
            : base("name=CRMEntities")
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<IdentityUserData> UserData { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Contact>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Contact>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("UserRole").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<Task>()
                .Property(e => e.Priority)
                .IsFixedLength();

            modelBuilder.Entity<Task>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Task>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Sum)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Date)
                .HasColumnType("datetime2");

            modelBuilder.Entity<User>()
                .Property(e => e.PhotoPath)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Tasks)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.ResponsibleUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Transactions)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.ResponsibleUserId);

            modelBuilder.Entity<User>()
                .HasRequired(e => e.UserData)
                .WithOptional()
                .Map(e => e.MapKey("UserDataId"));
        }

        // for getting context through OWIN
        public static CRMEntities Create()
        {
            return new CRMEntities();
        }
    }
}
