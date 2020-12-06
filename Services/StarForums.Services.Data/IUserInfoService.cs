using StarForums.Web.ViewModels.Info;
using System.Threading.Tasks;

namespace StarForums.Services.Data
{
    public interface IUserInfoService
    {
        T GetById<T>(string userId);

        Task CreateInfoAsync(string userId);

        Task UpdateInfoAsync(UserInfoInputModel model);
    }
}
