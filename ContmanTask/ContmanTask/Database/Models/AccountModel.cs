using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ContmanTask.Database.Models
{
    [Table("account", Schema = "contman_task_database")]
    public class AccountModel
    {
        public AccountModel()
        {
            EmailAddress = new HashSet<EmailAddressModel>();
        }
        [Key]
        [Column("account_name")]
        public string AccountName { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmailAddressModel> EmailAddress { get; set; }
    }
}
