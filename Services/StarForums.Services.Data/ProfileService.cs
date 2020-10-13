namespace StarForums.Services.Data
{
    using System.Linq;

    using StarForums.Data.Common.Repositories;
    using StarForums.Data.Models;
    using StarForums.Services.Mapping;

    public class ProfileService : IProfileService
    {
        private readonly IRepository<ApplicationUser> repository;

        public ProfileService(IRepository<ApplicationUser> repository)
        {
            this.repository = repository;
        }

        public T GetProfileByUserId<T>(string userId)
        {
            var user = this.repository.All().Where(x => x.Id == userId);

            return user.To<T>().FirstOrDefault();
        }
    }
}
