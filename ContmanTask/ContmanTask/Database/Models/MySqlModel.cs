
namespace ContmanTask.Database.Models
{
    using System.Data.Entity;
    public partial class MySqlModel : DbContext
    {
        public MySqlModel() : base("name=MySqlModel")
        {
            Database.SetInitializer<MySqlModel>(null);
            this.Configuration.UseDatabaseNullSemantics = true;
        }
        public virtual DbSet<AccountModel> Account { get; set;}
        public virtual DbSet<EmailAddressModel> EmailAddress{get; set;}
        public virtual DbSet<EmailGroupModel> EmailGroup{get; set;}
    }
}
