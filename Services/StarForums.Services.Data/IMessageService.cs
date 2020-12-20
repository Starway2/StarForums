namespace StarForums.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMessageService
    {
        IEnumerable<T> GetAllReceivedByUserId<T>(string userId);

        IEnumerable<T> GetAllSentByUserId<T>(string userId);

        Task SendMessageAsync(string content, string title, string receiverId, string senderId);
    }
}
