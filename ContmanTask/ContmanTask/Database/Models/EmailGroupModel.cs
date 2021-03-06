﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ContmanTask.Database.Models
{
    [Table("email_address", Schema = "contman_task_database")]
    public class EmailGroupModel
    {
        public EmailGroupModel()
        {
            Emails = new HashSet<EmailAddressModel>();
        }
        [Key]
        [Column("group_id")]
        public int GroupId { get; set; }
        [Column("group_name")]
        public string GroupName { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmailAddressModel> Emails { get; set; }
    }
}
