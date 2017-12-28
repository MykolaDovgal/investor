using Investor.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;

namespace Investor.Repository
{
    public class NewsContext : IdentityDbContext<UserEntity> 
    {
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<BlogEntity> Blogs { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<NewsEntity> News { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        //public DbSet<ClientEntity> Clients { get; set; }

        public NewsContext(DbContextOptions<NewsContext> options) 
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  
            modelBuilder.Entity<PostTagEntity>()
             .HasKey(t => new { t.PostId, t.TagId });

            modelBuilder.Entity<PostTagEntity>()
                .HasOne(pt => pt.Post)
                .WithMany(pt=>pt.PostTags)
                .HasForeignKey(pt=>pt.PostId);

            modelBuilder.Entity<PostTagEntity>()
               .HasOne(pt => pt.Tag)
               .WithMany(pt => pt.PostTags)
               .HasForeignKey(pt => pt.TagId);


            //modelBuilder.Entity<ClientPostEntity>()
            //    .HasKey(t => new { t.PostId, t.ClientId });

            //modelBuilder.Entity<ClientPostEntity>()
            //    .HasOne(pt => pt.Post)
            //    .WithMany(pt => pt.ClientVisits)
            //    .HasForeignKey(pt => pt.PostId);

            //modelBuilder.Entity<ClientPostEntity>()
            //    .HasOne(pt => pt.Client)
            //    .WithMany(pt => pt.PostVisits)
            //    .HasForeignKey(pt => pt.ClientId);

            base.OnModelCreating(modelBuilder);
        }

        public async void EnsureSeedData(UserManager<UserEntity> userMgr, RoleManager<IdentityRole> roleMgr)
        {
            // Create roles and role claims 
            var user = await userMgr.FindByIdAsync("dev@dev.com");

            // Add user to claim and role
            if (user != null) return;

            // Create roles and role claims 
            var adminRole = await roleMgr.FindByNameAsync("admin");
            if (adminRole == null)
            {
                adminRole = new IdentityRole("admin");
                //adminRole.Claims.Add(new IdentityRoleClaim<string> { ClaimType = "isAdmin", ClaimValue = "true" });
                await roleMgr.CreateAsync(adminRole);
            }

            user = new UserEntity
            {
                UserName = "dev@dev.com"
            };

            var userResult = await userMgr.CreateAsync(user, "dev");
            var roleResult = await userMgr.AddToRoleAsync(user, "admin");
            var claimResult = await userMgr.AddClaimAsync(user, new Claim("superUser", "true"));

            if (!userResult.Succeeded || !roleResult.Succeeded || !claimResult.Succeeded)
            {
                throw new InvalidOperationException("Failed to build user and roles");
            }
        }
    }
}
