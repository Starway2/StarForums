namespace StarForums.Services.Data
{
    using System.Linq;

    using StarForums.Data.Common.Repositories;
    using StarForums.Data.Models;
    using StarForums.Services.Mapping;

    public class UserInfoService : IUserInfoService
    {
        private readonly IRepository<UserInfo> repository;

        public UserInfoService(IRepository<UserInfo> repository)
        {
            this.repository = repository;
        }

        public async void CreateInfoAsync(string userId)
        {
            var info = new UserInfo()
            {
                UserId = userId,
            };
            await this.repository.AddAsync(info);
            await this.repository.SaveChangesAsync();
        }

        public T GetById<T>(string userId) => this.repository.All().Where(x => x.UserId == userId).To<T>().FirstOrDefault();
    }
}
