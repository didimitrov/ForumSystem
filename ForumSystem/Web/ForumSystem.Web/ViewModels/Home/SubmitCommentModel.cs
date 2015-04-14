using System.ComponentModel.DataAnnotations;

namespace ForumSystem.Web.ViewModels.Home
{
    public class SubmitCommentModel
    {
        [Required]
        //[ShouldNotContainEmail]
        public string Comment { get; set; }


        [Required]
        public int PostId { get; set; }
    }
}