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
            this.Posts=new List<Post>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }

        public virtual Category Category { get; set; }
        [Index]
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
