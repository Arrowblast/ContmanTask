
namespace ContmanTask.Database.Models
{
    using Microsoft.EntityFrameworkCore;
    using MySQL.Data.EntityFrameworkCore;
    public partial class MySqlModel : DbContext
    {
        public MySqlModel() : base()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(Startup.connectionString);
        }
        public virtual DbSet<AccountModel> Account { get; set;}
        public virtual DbSet<EmailAddressModel> EmailAddress{get; set;}
        public virtual DbSet<EmailGroupModel> EmailGroup{get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EmailGroupModel>().
                HasMany(e => e.Emails).
                WithOne(e => e.Group).HasForeignKey(e =>e.GroupId);
            modelBuilder.Entity<AccountModel>().
                HasMany(e => e.EmailAddress).
                WithOne(e => e.Account).HasForeignKey(e => e.AccountName);
            modelBuilder.Entity<EmailGroupModel>().ToTable("email_group");
            modelBuilder.Entity<EmailAddressModel>().ToTable("email_address");
            modelBuilder.Entity<AccountModel>().ToTable("account");
            /*modelBuilder.Entity<EmailAddressModel>().Map(m => m.ToTable("email_address"));
            modelBuilder.Entity<AccountModel>().Map(m => m.ToTable("account"));
            modelBuilder.Entity<EmailGroupModel>().Map(m => m.ToTable("email_group"));*/


        }
    }
}
