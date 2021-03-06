namespace Classbook.App
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    using System;
    using System.Reflection;

    using Classbook.App.Areas.Identity;
    using Classbook.App.Components.Common.Modal;
    using Classbook.App.Components.Common.ToastNotifications;
    using Classbook.App.Infrastructure.ElectronUtitlity;
    using Classbook.App.Models.Grades;
    using Classbook.Data;
    using Classbook.Data.Models;
    using Classbook.Services.Data;
    using Classook.Services.Mapping;
    using Classbook.Services.Models;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ClassbookDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging());

            services.AddDefaultIdentity<ApplicationUser>(options => IdentityOptionsProvider.GetIdentityOptions(options))
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ClassbookDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddTransient<ISchoolYearService, SchoolYearService>();
            services.AddTransient<IGradeService, GradeService>();
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<IGradeClassService, GradeClassService>();

            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddScoped<IToastService, ToastService>();
            services.AddScoped<IModalService, ModalService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(
                typeof(GradeInputModel).GetTypeInfo().Assembly,
                typeof(SchoolYearDto).GetTypeInfo().Assembly);

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ClassbookDbContext>();

                dbContext.Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            ElectronHelper.Window.ElectronBootstrap();
        }
    }
}
