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
using Investor.Web.Areas.Admin.Attribute;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Investor.Service.Utils;
using Investor.Service.Utils.Interfaces;
using Investor.Web.Filters;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.ResponseCompression;

namespace Investor.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddScoped<HitCount>();

            services.AddDbContext<NewsContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
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
            services.AddTransient<ITagRepository, TagRepository>();
            services.AddTransient<INewsRepository, NewsRepository>();
            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IStatisticsRepository, StatisticsRepository>();

            //services.AddTransient<ImagePathService>();
            //services.AddTransient<IMemoryCache, MemoryCache>();
            services.AddMemoryCache();
            // Services
            services.AddTransient<IImagePathService, ImagePathService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<ISearchService, SearchService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<IStatisticsService, StatisticsService>();


            services.AddTransient<IpService>();
            services.AddTransient<TimeService>();
            services.AddTransient<CurrencyService>();
            services.AddTransient<CacheService>();
            services.AddTransient<UrlService>();

            services.AddMvc();
            services.AddAutoMapper();

            services.AddDistributedMemoryCache();
            services.AddSession();

            services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.AddResponseCompression(options =>
            {
                options.MimeTypes = new[]
                {
                    "text/plain",
                    "text/css",
                    "application/javascript",
                    "text/html",
                    "application/xml",
                    "text/xml",
                    "application/json",
                    "text/json"
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminAuthorize", policy =>
                    policy.Requirements.Add(new RoleAuthorizeRequirement("admin")));
            });

            services.AddSingleton<IAuthorizationHandler, AdminAuthorize>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //ServiceMapperConfig.Config();

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

            app.UseStatusCodePagesWithReExecute("/StatusCode/{0}");

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                                   ForwardedHeaders.XForwardedProto
            });
            app.UseResponseCompression();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseSession();
            

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}");
                routes.MapRoute("login", "login",
                    defaults: new { controller = "Account", action = "Login" });

                routes.MapRoute("register", "register",
                    defaults: new { controller = "Account", action = "Register" });

                routes.MapRoute("lastnews", "lastnews",
                    defaults: new { controller = "Post", action = "LastNews" });

                routes.MapRoute("blog", "blog/{blogUrl}-{blogId:int}",
                    defaults: new { controller = "Blog", action = "Page" });

                routes.MapRoute("post", "{category}/{postUrl}-{postId:int}",
                    defaults: new { controller = "Post", action = "Index" });

                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute("category", "{categoryUrl:regex(^[a-zA-Z]+$)}",
                    defaults: new { controller = "Category", action = "Index" });

                

                
            });
        }
    }
}