using System;
using _20200921.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(_20200921.Areas.Identity.IdentityHostingStartup))]
namespace _20200921.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<UserContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("UserContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<UserContext>();
            });
        }
    }
}