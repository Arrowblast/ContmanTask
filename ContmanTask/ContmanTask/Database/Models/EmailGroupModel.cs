using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContmanTask.Database.Models
{
    [Table("email_address", Schema = "contman_task_database")]
    public class EmailGroupModel
    {
        [Key]
        [Column("group_id")]
        public int GroupId { get; set;}
        [Column("group_name")]
        public string GroupName { get; set;}
    }
}
