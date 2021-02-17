using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContmanTask.Database.Models
{
    [Table("account",Schema ="contman_task_database")]
    public class AccountModel
    {
        [Key]
        [Column("account_name")]
        public string AccountName { get; set;}
        [Column("email")]
        public string Email { get;set;}
    }
}
