using Marizona.WebUI.AppCode.Middlewares;
using Marizona.WebUI.Core.Extensions;
using Marizona.WebUI.Core.Provider;
using Marizona.WebUI.Models.DataContexts;
using Marizona.WebUI.Models.Entities.Membership;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace Marizona.WebUI
{
    public class Startup
    {
        readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
            string myKey = "Marizona";

            string plainText = "test";

            //string hashedText = plainText.toMd5();

            string chiperText = plainText.Encrypt(myKey);

            string myPlainText = chiperText.Decrypt(myKey);

        }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews(cfg =>
            {

                var policy = new AuthorizationPolicyBuilder()
                 .RequireAuthenticatedUser()
                 .Build();
                cfg.Filters.Add(new AuthorizeFilter(policy));

            });


            services.AddRouting(cfg => cfg.LowercaseUrls = true);

            services.AddDbContext<MarizonaDbContext>(cfg =>
            {

                // ve burda cagirib yaziriq appsettings adini 
                cfg.UseSqlServer(configuration.GetConnectionString("cString"));

            }, ServiceLifetime.Scoped);


            //Membership ucun yazilib.
            services.AddIdentity<MarizonaUser, MarizonaRole>()
                .AddEntityFrameworkStores<MarizonaDbContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(cfg =>
            {

                cfg.Password.RequireDigit = false; //Reqem teleb elesin?
                cfg.Password.RequireUppercase = false; //Boyuk reqem teleb elesin?
                cfg.Password.RequireLowercase = false; //Kick reqem teleb elesin?
                cfg.Password.RequiredUniqueChars = 1; //Tekrarlanmiyan nece  sombol olsun?(11-22-3)
                cfg.Password.RequireNonAlphanumeric = false; // 0-9 a-z A-Z  Olmayanlari teleb elemesin?
                cfg.Password.RequiredLength = 3; //Password nece simboldan ibaret olsun?

                cfg.User.RequireUniqueEmail = true; //Email tekrarlanmasin 1 adam ucun?
                //cfg.User.AllowedUserNameCharacters = ""; //User neleri isdifade eliye biler?

                cfg.Lockout.MaxFailedAccessAttempts = 3;// 3 seferden cox sefh giris etse diyansin?
                cfg.Lockout.DefaultLockoutTimeSpan = new TimeSpan(0, 2, 0);//Nece deq gozlesin ?


            });


            services.ConfigureApplicationCookie(cfg =>
            {

                cfg.LoginPath = "/signin.html"; //Eger adam login olunmuyubsa hara gondersin?

                cfg.AccessDeniedPath = "/accessdenied.html";//Senin icazen var bu linke yeni link atanda gire bilmesin diye (yeni fb nese atanda ve ya tiktokda olanda beyenmek olmur zad)

                cfg.ExpireTimeSpan = new TimeSpan(0, 10, 10);//Seni sayitda nece deq saxlasin eger sen hecne elemirsense atacaq yeni login olduqdan sonra diansan ve ya saty girdikden sonra diansan

                cfg.Cookie.Name = "Marizona"; //Cookie adi ne olsun isdediyin adi yaza bilersen;

            });


            services.AddAuthentication();
            services.AddAuthorization();

            services.AddScoped<UserManager<MarizonaUser>>();
            services.AddScoped<SignInManager<MarizonaUser>>();


        }









        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
         //   app.SeedMembership();
            app.UseRouting();

            app.UseRequestLocalization(cfg => {

                cfg.AddSupportedUICultures("az", "en");
                cfg.AddSupportedCultures("az", "en");

                cfg.RequestCultureProviders.Clear();
                cfg.RequestCultureProviders.Add(new CultureProvider());
            });


            app.Use(async (context, next) =>
            {
                if (!context.User.Identity.IsAuthenticated
                && !context.Request.Cookies.ContainsKey("Marizona")
                && context.Request.RouteValues.TryGetValue("area", out object areaName)
                && areaName.ToString().ToLower().Equals("admin"))
                {
                    var attr = context.GetEndpoint().Metadata.GetMetadata<AllowAnonymousAttribute>();
                    //eger actionin ustunde allowanonymous atributu varsa onda normal nexte dussun yoxdursa o zaman yonlensin signine 
                    if (attr == null)
                    {
                        context.Response.Redirect("/admin/signin.html");
                        await context.Response.CompleteAsync();
                    }

                }
                await next();
            });

            app.UseAudit();
          //  app.SeedMembership();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(

                   name: "Default-signin",
                   pattern: "accessdenied.html",
                   defaults: new
                   {
                       areas = "",
                       controller = "Account",
                       action = "accessdenied"
                   });


                endpoints.MapGet("/coming-soon.html", async (context) =>
                {
                    using (var sr = new StreamReader("views/static/coming-soon.html"))
                    {
                        context.Response.ContentType = "text/html";
                        await context.Response.WriteAsync(sr.ReadToEnd());
                    }
                });

                endpoints.MapControllerRoute("admin_signIn", "admin/signin.html",
                    defaults: new
                    {
                        controller = "Account",
                        action = "Login",
                        area = "Admin"
                    });

                endpoints.MapControllerRoute("default_signIn", "signin.html",
                    defaults: new
                    {
                        controller = "Account",
                        action = "SignIn",
                        area = ""
                    });

                endpoints.MapControllerRoute("admin_signOut", "admin/logout.html",
                    defaults: new
                    {
                        controller = "Account",
                        action = "Logout",
                        area = "Admin"
                    });

                endpoints.MapControllerRoute(
                      name: "areas-with-lang",
                      pattern: "{lang}/{area:exists}/{controller=Dashboard}/{action=Index}/{id?}",
                      constraints: new
                      {
                          lang = "en|az|ru"
                      }
                    );

                endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                    );

                endpoints.MapControllerRoute("default-with-lang", "{lang}/{controller=home}/{action=index}/{id?}",
                    constraints: new
                    {
                        lang = "en|az|ru"
                    });
                endpoints.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}
