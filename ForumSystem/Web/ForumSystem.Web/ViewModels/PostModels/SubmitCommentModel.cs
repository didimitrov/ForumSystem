﻿using System.ComponentModel.DataAnnotations;

namespace ForumSystem.Web.ViewModels.PostModels
{
    public class SubmitCommentModel
    {
        public int Id { get; set; }

        [Required]
        //[ShouldNotContainEmail]
        public string Comment { get; set; }


        
        public int PostId { get; set; }

        public int? ParentId { get; set; }
    }
}