using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContmanTask.Database.Models
{
    [Table("email_address",Schema ="contman_task_database")]
    public class EmailAddressModel
    {

        [Key]
        [Column("email")]
        public string Email { get; set;}
        [Column("group_id")]
        public int? GroupId { get; set;}
        [Column("account_name")]
        public string AccountName { get; set; }
        
        public virtual EmailGroupModel Group { get; set; }
        [Required]
        public virtual AccountModel Account { get; set; }
    }
}
