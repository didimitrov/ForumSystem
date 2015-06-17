using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ForumSystem.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }

        public int PostId { get; set; }
        public virtual Post Post { get; set; }


        public int? ParentId { get; set; }
        public Comment[] ChildComments { get; set; }

        public DateTime DateTime { get; set; }
    }
}
