using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ForumSystem.Models;
using ForumSystem.Web.Infrastructure.Mapping;
using ForumSystem.Web.ViewModels.PostModels;

namespace ForumSystem.Web.ViewModels.Questions
{
    public class QuestionDetailsViewModel :IMapFrom<Post>
    {
        public QuestionDetailsViewModel()
        {
            Comments= new List<CommentViewModel>();
           // CountComm = Comments.Count;
           
        }
        
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }
        
        public string Content { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        public bool UserCanVote { get; set; }

        public int Votes { get; set; }

        public int CountComm { get;  set; }

        public List<CommentViewModel> Comments { get; set; }

        [Display(Name = "Author")]
        public string AuthorId { get; set; }

        //public ApplicationUser Author { get; set; }
    }
}