using Microsoft.AspNetCore.Identity;
using ProjectSensive.BusinessLayer.Abstract;
using ProjectSensive.BusinessLayer.Concrete;
using ProjectSensive.DataAccessLayer.Abstract;
using ProjectSensive.DataAccessLayer.Context;
using ProjectSensive.DataAccessLayer.EntityFramework;
using ProjectSensive.EntityLayer.Concrete;
using ProjectSensive.PresentationLayer.Models;

namespace ProjectSensive.PresentationLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ContextSensive>();

            builder.Services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<ContextSensive>()
                .AddDefaultTokenProviders()
                .AddErrorDescriber<CustomIdentityValidator>();


            builder.Services.AddScoped<IAppUserDal, EfAppUserDal>();
            builder.Services.AddScoped<IAppUserService, AppUserManager>();

            builder.Services.AddScoped<IArticleDal, EfArticleDal>();
            builder.Services.AddScoped<IArticleService, ArticleManager>();

            builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
            builder.Services.AddScoped<ICategoryService, CategoryManager>();

            builder.Services.AddScoped<ICommentDal, EfCommentDal>();
            builder.Services.AddScoped<ICommentService, CommentManager>();

            builder.Services.AddScoped<IContactDal, EfContactDal>();
            builder.Services.AddScoped<IContactService, ContactManager>();

            builder.Services.AddScoped<INewsletterDal, EfNewsletterDal>();
            builder.Services.AddScoped<INewsletterService, NewsletterManager>();

            builder.Services.AddScoped<ITagCloudDal, EfTagCloudDal>();
            builder.Services.AddScoped<ITagCloudService, TagCloudManager>();






            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");



            app.Run();
        }
    }
}
