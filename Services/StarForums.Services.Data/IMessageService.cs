namespace StarForums.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMessageService
    {
        IEnumerable<T> GetAllReceivedByUserId<T>(string userId);

        IEnumerable<T> GetAllSentByUserId<T>(string userId);

        T GetById<T>(int id);

        Task SendMessageAsync(string content, string title, string receiverId, string senderId);
    }
}
