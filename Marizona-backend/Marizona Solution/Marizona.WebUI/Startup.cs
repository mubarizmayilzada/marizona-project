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

            //3.1
            services.AddControllersWithViews(cfg => {
                cfg.ModelBinderProviders.Insert(0, new BooleanBinderProvider());  //8.1

                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                cfg.Filters.Add(new AuthorizeFilter(policy));
            })
                //eger productla branddaki kimi referens ozu ozunu cagirirsa
                .AddNewtonsoftJson(cfg =>
                    cfg.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                );


            services.AddControllersWithViews();
            services.AddDbContext<MarizonaDbContext>();



            var asmbls = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("Marizona."))
                .ToArray();

            services.AddIdentity<MarizonaUser, MarizonaRole>()
                .AddEntityFrameworkStores<MarizonaDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<UserManager<MarizonaUser>>(); //4.2
            services.AddScoped<RoleManager<MarizonaRole>>();  //4.3
            services.AddScoped<SignInManager<MarizonaUser>>();  //4.4
            //realtimeda deyisiklikler tetbiq olunsun
            services.AddScoped<IClaimsTransformation, AppClaimProvider>();

            services.Configure<IdentityOptions>(cfg =>
            {
                cfg.Password.RequireDigit = false;
                cfg.Password.RequireUppercase = false;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequiredUniqueChars = 1;
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequiredLength = 3;

                cfg.User.RequireUniqueEmail = true;

                cfg.Lockout.MaxFailedAccessAttempts = 3;
                cfg.Lockout.DefaultLockoutTimeSpan = new TimeSpan(0, 3, 0);

                cfg.SignIn.RequireConfirmedEmail = true;
            });

            services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/signin.html";
                cfg.AccessDeniedPath = "/accessdenied.html";

                cfg.ExpireTimeSpan = new TimeSpan(0, 5, 0);
                cfg.Cookie.Name = "Marizona";
            });

            services.AddAuthentication(); //senin umumiyyetle girmeye selahiyyetin var ya yox

            //senin hara girmeye selahiyyetin var
            services.AddAuthorization(cfg =>
            {
                foreach (var item in Extension.principals)
                {
                    cfg.AddPolicy(item, p =>
                    {
                        p.RequireAssertion(h =>
                        {
                            return h.User.IsInRole("SuperAdmin") ||
                            h.User.HasClaim(item, "1");
                            //burda nie h.Role.HasClaim elemedikki tekce userde yoxluyurug
                        });
                    });
                }

            });

            //var asmbls = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("Riode."))
            //    .ToArray();
            //services.AddMediatR(asmbls);

            //services.AddAutoMapper(asmbls);

        }









        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.SeedMembership();
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
                && !context.Request.Cookies.ContainsKey("riode")
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
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
