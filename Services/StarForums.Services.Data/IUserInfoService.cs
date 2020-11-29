namespace StarForums.Services.Data
{
    public interface IUserInfoService
    {
        T GetById<T>(string userId);

        void CreateInfoAsync(string userId);
    }
}
