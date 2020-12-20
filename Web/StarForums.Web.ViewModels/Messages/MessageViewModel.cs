namespace StarForums.Web.ViewModels.Messages
{
    using StarForums.Data.Models;
    using StarForums.Services.Mapping;

    public class MessageViewModel : IMapFrom<Message>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string ReceiverId { get; set; }

        public string SenderUsernme { get; set; }
    }
}
