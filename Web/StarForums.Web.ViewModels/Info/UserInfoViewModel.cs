namespace StarForums.Web.ViewModels.Info
{
    using System;

    using StarForums.Data.Models;
    using StarForums.Services.Mapping;

    public class UserInfoViewModel : IMapFrom<UserInfo>
    {
        public string UserUsername { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string Instagram { get; set; }

        public string Skype { get; set; }

        public string PhoneNumber { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
