using System;
using System.ComponentModel.DataAnnotations.Schema;
using ForumSystem.Common.Models;

namespace ForumSystem.Models
{
    public class Tag : AuditInfo , IDeletableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Index]
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
