namespace StarForums.Services.Data
{
    using System.IO;
    using System.Threading.Tasks;

    public interface IProfileService
    {
        T GetProfileByUserId<T>(string userId);

        Task<bool> ChangeAvatar(string fileName, MemoryStream file, string userId);

        Task ChangeSignature(string signature, string userId);
    }
}
