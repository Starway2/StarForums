namespace StarForums.Services.Data
{
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
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

        public async Task<bool> ChangeAvatar(string fileName, MemoryStream file, string userId)
        {
            var user = this.repository.All().Where(x => x.Id == userId).FirstOrDefault();

            if (user == null)
            {
                return false;
            }

            // TODO: Change to appsettings
            Account account = new Account("dbda9nvbi", "133387568673539", "oOpSW_8IXzPVsbZ2ii7HRPpSerw");

            Cloudinary cloudinary = new Cloudinary(account);

            file.Position = 0;

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileName, file),
                PublicId = fileName,
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            user.AvatarUrl = uploadResult.Url.ToString();
            this.repository.Update(user);
            await this.repository.SaveChangesAsync();

            return true;
        }

        public async Task ChangeSignature(string signature, string userId)
        {
            var user = this.repository.All().Where(x => x.Id == userId).FirstOrDefault();

            user.Signature = signature;

            this.repository.Update(user);
            await this.repository.SaveChangesAsync();
        }

        public T GetProfileByUserId<T>(string userId)
        {
            var user = this.repository.All().Where(x => x.Id == userId);

            return user.To<T>().FirstOrDefault();
        }
    }
}
