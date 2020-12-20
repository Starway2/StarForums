namespace StarForums.Web.ViewModels.Messages
{
    using System.Collections.Generic;

    public class MessageListViewModel
    {
        public ICollection<MessageViewModel> Messages { get; set; }
    }
}
