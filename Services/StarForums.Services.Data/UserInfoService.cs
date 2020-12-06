namespace StarForums.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using StarForums.Data.Common.Repositories;
    using StarForums.Data.Models;
    using StarForums.Services.Mapping;
    using StarForums.Web.ViewModels.Info;

    public class UserInfoService : IUserInfoService
    {
        private readonly IRepository<UserInfo> repository;

        public UserInfoService(IRepository<UserInfo> repository)
        {
            this.repository = repository;
        }

        public async Task CreateInfoAsync(string userId)
        {
            var info = new UserInfo()
            {
                UserId = userId,
            };
            await this.repository.AddAsync(info);
            await this.repository.SaveChangesAsync();
        }

        public T GetById<T>(string userId) => this.repository.All().Where(x => x.UserId == userId).To<T>().FirstOrDefault();

        public async Task UpdateInfoAsync(UserInfoInputModel model)
        {
            var info = this.repository.All().Where(x => x.Id == model.Id).FirstOrDefault();

            info.BirthDate = model.BirthDate;
            info.City = model.City;
            info.Country = model.Country;
            info.Facebook = model.Facebook;
            info.Gender = model.Gender;
            info.Instagram = model.Instagram;
            info.Name = model.Name;
            info.PhoneNumber = model.PhoneNumber;
            info.Skype = model.Skype;
            info.Twitter = model.Twitter;

            this.repository.Update(info);
            await this.repository.SaveChangesAsync();
        }
    }
}
