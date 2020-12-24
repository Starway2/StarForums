namespace StarForums.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using StarForums.Data.Common.Repositories;
    using StarForums.Data.Models;
    using StarForums.Services.Mapping;

    public class MessageService : IMessageService
    {
        private readonly IDeletableEntityRepository<Message> repository;

        public MessageService(IDeletableEntityRepository<Message> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<T> GetAllReceivedByUserId<T>(string userId) => this.repository.All().Where(x => x.ReceiverId == userId).To<T>().ToList();

        public IEnumerable<T> GetAllSentByUserId<T>(string userId) => this.repository.All().Where(x => x.SenderId == userId).To<T>().ToList();

        public T GetById<T>(int id) => this.repository.All().Where(x => x.Id == id).To<T>().FirstOrDefault();

        public async Task SendMessageAsync(string content, string title, string receiverId, string senderId)
        {
            var message = new Message()
            {
                Title = title,
                Content = content,
                SenderId = senderId,
                ReceiverId = receiverId,
            };

            await this.repository.AddAsync(message);
            await this.repository.SaveChangesAsync();

        }
    }
}
