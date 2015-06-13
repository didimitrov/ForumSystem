using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ForumSystem.Common.Models;

namespace ForumSystem.Models
{
   public class Category : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        [Display(Name = "Category")]
        public string Title { get; set; }

        //public string Description { get; set; }

        //[DisplayName("Category Img URL")]
        //public string CategoryImgUrl { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

       public bool IsDeleted { get; set; }
       public DateTime? DeletedOn { get; set; }
    }
}
