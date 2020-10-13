namespace StarForums.Web.ViewModels.Profile
{
    using System;

    using StarForums.Data.Models;
    using StarForums.Services.Mapping;

    public class ProfileViewModel : IMapFrom<ApplicationUser>
    {
        public string Username { get; set; }

        public int PostsCount { get; set; }

        public int CommentsCount { get; set; }

        public string AvatarUrl { get; set; }

        public string Email { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
