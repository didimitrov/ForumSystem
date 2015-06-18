using System;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using ForumSystem.Common.Models;

namespace ForumSystem.Models
{
    public class Vote :AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public string VotedById { get; set; }
        public virtual ApplicationUser VotedBy { get; set; }

        public int? PostId { get; set; }
        public virtual Post Post { get; set; }

        public int? CommentId { get; set; }
        public virtual Comment Comment { get; set; }
        
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
