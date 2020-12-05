namespace StarForums.Web.ViewModels.Info
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using StarForums.Data.Models;
    using StarForums.Services.Mapping;

    public class UserInfoInputModel : IMapFrom<UserInfo>
    {
        public int Id { get; set; }

        public string UserUsername { get; set; }

        public string UserId { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        public string Gender { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string Instagram { get; set; }

        public string Skype { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
