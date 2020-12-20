namespace StarForums.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using StarForums.Data.Models;
    using StarForums.Services.Data;
    using StarForums.Web.ViewModels.Messages;

    public class MessageController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMessageService service;

        public MessageController(UserManager<ApplicationUser> userManager, IMessageService service)
        {
            this.userManager = userManager;
            this.service = service;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userId = this.userManager.GetUserId(this.User);

            var messages = this.service.GetAllReceivedByUserId<MessageViewModel>(userId).ToList();
            var model = new MessageListViewModel() { Messages = messages };

            return this.View(model);
        }

        [Authorize]
        public IActionResult Sent()
        {
            return this.View();
        }

        [Authorize]
        public IActionResult Send()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Send(MessageInputModel model)
        {
            if (!this.ModelState.IsValid || this.User.Identity.Name != model.SenderUsername)
            {
                return this.View(model);
            }

            var receiver = await this.userManager.FindByNameAsync(model.ReceiverUsername);

            if (receiver == null)
            {
                this.ModelState.AddModelError("ReceiverUsername", "User with that username doesn't exist!");
                return this.View(model);
            }

            var sender = await this.userManager.FindByNameAsync(this.User.Identity.Name);

            if (receiver.Id == sender.Id)
            {
                this.ModelState.AddModelError("ReceiverUsername", "You cannot send message to yourself!");
                return this.View(model);
            }

            await this.service.SendMessageAsync(model.Content, model.Title, receiver.Id, sender.Id);

            return this.RedirectToAction("Index");
        }
    }
}
