using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Investor.Repository;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Investor.Service;
using Investor.Repository.Interfaces;
using Investor.Service.Interfaces;
using Investor.Entity;
using Microsoft.AspNetCore.Identity;

namespace Investor.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NewsContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("GearConnection")));
            // Add framework services.

            services.AddIdentity<UserEntity, IdentityRole>(opts =>
            {
                opts.Password.RequiredLength = 6;   
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false; 
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<NewsContext>()
            .AddDefaultTokenProviders();


            services.AddTransient<ICategoryRepository, CategoryRepository>();
            //services.AddTransient<ITagRepository, TagRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<ISliderItemRepository, SliderItemRepository>();
            services.AddTransient<IPostTagRepository, PostTagRepository>();
            services.AddTransient<TimeService>();
            services.AddTransient<ThemeService>();
            // Services
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ISliderItemService, SliderItemService>();
            //services.AddTransient<IPostTagService, PostTagService>();
            //services.AddTransient<ISearchService, SearchService>();
            //services.AddTransient<ICommunicationService, CommunicationService>();
            //services.AddTransient<ITagService, TagService>();
            //services.AddTransient<ISiteMapService, SiteMapService>();
            //ervices.AddTransient<ApplicationEnvironment>();

            services.AddMvc();
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            ServiceMapperConfig.Config();

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute("post", "post/{id}",
                    defaults: new { controller = "Post", action = "Index" });

                routes.MapRoute("blog", "category/{url}",
                    defaults: new { controller = "Category", action = "Index" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}