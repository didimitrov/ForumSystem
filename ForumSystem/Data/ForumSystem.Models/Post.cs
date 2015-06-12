using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ForumSystem.Common.Models;

namespace ForumSystem.Models
{
    public class Post : AuditInfo, IDeletableEntity
    {
        public Post()
        {
            Comments= new HashSet<Comment>();
            AskedOn = DateTime.Now;
            this.Votes= new HashSet<Vote>();
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public string Content { get; set; }
        
        public DateTime AskedOn { get; set; }
        public string AuthorId { get; set; }
        public virtual ApplicationUser  Author { get; set; }

        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
