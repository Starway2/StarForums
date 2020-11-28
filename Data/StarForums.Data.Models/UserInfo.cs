namespace StarForums.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserInfo
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string Instagram { get; set; }

        public string Skype { get; set; }

        public string PhoneNumber { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
