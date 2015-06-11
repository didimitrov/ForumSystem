using AutoMapper;
using ForumSystem.Models;
using ForumSystem.Web.Infrastructure.Mapping;

namespace ForumSystem.Web.ViewModels.SideBar
{
    public class TagViewModel:IMapFrom<Tag>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public int PostCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Tag, TagViewModel>()
                .ForMember(m => m.PostCount, opt => opt.MapFrom(u => u.Posts.Count));
        }
    }
}