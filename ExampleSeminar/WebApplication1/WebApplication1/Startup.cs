using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.CustromRequirements;
using WebApplication1.Handlers;

namespace WebApplication1
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // them cac services ma tat ca chuong trinh su dung den
            // cac service duoc add den DI container, va khi mot service nao đó cần thì sẽ được DI container cấp đến mà ta k cần phải tạo cái services đó.
            services.AddControllers();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookie";
                options.DefaultChallengeScheme = "Cookie";
            })
                .AddCookie("Cookie", options =>
                {
                    options.LoginPath = "/Account/Login";
                    // cookie
                })
                .AddOAuth("oauth", options =>
                {
                    options.AuthorizationEndpoint = "https://indeityServer/authorize";// clientid+ secret + state (duong dan ban dau ma user muon den) +redirectUri
                    options.TokenEndpoint = "https://indeityServer/token"; //Middleware
                    options.CallbackPath = "/callback";// redirect cookie
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("custom", policyBuilder =>
                {
                    policyBuilder.RequireClaim("email", "abc@gmail.com");
                });
                options.AddPolicy("custom", policyBuilder =>
                {
                    policyBuilder.AddRequirements(new CustomRequirement(1));
                    policyBuilder.AddRequirements(new CustomRequirement(2));
                });
            });

            services.AddSingleton<IAuthorizationHandler, CustomHandler1>();
            services.AddSingleton<IAuthorizationHandler, CustomHandler2>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // config middleware pipeline
            app.UseMiddleware<StatusMiddleware>();
            app.UseRouting();// thang nay luu lai key/value cua http request.
            app.UseAuthentication();// check xem co coookie hay token hay k, giai ma no va day thong tin vao user

            app.UseAuthorization();// action authorize hong? challenge

            // goi den controller action
            app.UseEndpoints(enpoint =>
            {
                //enpoint.MapControllers();
                //enpoint.MapControllerRoute("default", "{controller=home}/{action=index}{id?}");
                enpoint.MapDefaultControllerRoute();
            });
        }
    }
}