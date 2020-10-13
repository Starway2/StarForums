namespace StarForums.Services.Data
{
    public interface IProfileService
    {
        T GetProfileByUserId<T>(string userId);
    }
}
