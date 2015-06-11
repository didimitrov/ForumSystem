using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ForumSystem.Common.Models;

namespace ForumSystem.Models
{
    public class Tag : AuditInfo , IDeletableEntity
    {
        public Tag()
        {
            this.Posts=new HashSet<Post>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        [Index]
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
