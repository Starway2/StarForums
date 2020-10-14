using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(StarForums.Web.Areas.Identity.IdentityHostingStartup))]

namespace StarForums.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
