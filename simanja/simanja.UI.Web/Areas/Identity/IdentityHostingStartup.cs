using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(uangsaku.UI.Web.Areas.Identity.IdentityHostingStartup))]
namespace uangsaku.UI.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}