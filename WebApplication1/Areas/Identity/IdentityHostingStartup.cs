using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Models;

[assembly: HostingStartup(typeof(WebApplication1.Areas.Identity.IdentityHostingStartup))]
namespace WebApplication1.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LearningOutcomesContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LearningOutcomesContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<LearningOutcomesContext>();

                //services.AddDefaultIdentity<IdentityUser>(config => { config.SignIn.RequireConfirmedEmail = true; });

                //services.AddTransient<IEmailSender, EmailSender>();

            });
        }
    }
}