using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using WebApiTest.Areas.Identity.Data;
using WebApiTest.Models;

namespace WebApiTest.Data
{
    public class WebApiTestContext : IdentityDbContext<BlogUser>
    {
        public WebApiTestContext (DbContextOptions<WebApiTestContext> options)
            : base(options)
        {
        }

        public DbSet<WebApiTest.Models.Content> Content { get; set; } = default!;
        public DbSet<WebApiTest.Models.Category> Category { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // add seed data

            // Add User Data

            // string for the user account id

            const string AdminID = "febc0557-59ea-41d9-bc30-9b1aeac7d9c5";

            //const string RoleID = "4228a559-b351-42ea-8eaf-8830e8adfafc";

            //modelBuilder.Entity<IdentityRole>().HasData(
            //    new IdentityRole
            //    {
            //        Name = "Admin",
            //        NormalizedName = "ADMIN",
            //        Id = RoleID,
            //        ConcurrencyStamp = "64524b67-1c15-448d-bccd-547a0101e91a"
            //    }
            //);

            //BlogUser usr = new()
            //{
            //    Id = AdminID,
            //    Email = "SeedData@SeedData.com",
            //    NormalizedEmail = "SEEDDATA@SEEDDATA.COM",
            //    EmailConfirmed = true,
            //    UserName = "SeedData@SeedData.com",
            //    NormalizedUserName = "SEEDDATA@SEEDDATA.COM"
            //};

            //PasswordHasher<BlogUser> hasher = new();
            //usr.PasswordHash = hasher.HashPassword(usr, "1Forest1!");

            //modelBuilder.Entity<BlogUser>().HasData(usr);

            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            //    new IdentityUserRole<string>
            //    {
            //        RoleId = RoleID,
            //        UserId = AdminID
            //    }
            //);

            // Add Content Data
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Food",
                    PostedContent = []
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Tech",
                    PostedContent = []
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "News",
                    PostedContent = []
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Tacos",
                    PostedContent = []
                }
            );

            modelBuilder.Entity<Content>().HasData(
                new Content
                {
                    ContentId = 1,
                    Title = "First Post",
                    Body = "Lorem ipsum and stuff",
                    //AuthorId = AdminID, // TODO: add in a base user to use
                    CreatedAt = new DateTime(2025, 02, 03),
                    UpdatedAt = new DateTime(2025, 02, 03),
                    Visibility = VisibilityStatus.Visible,
                    CategoryId = 3,
                    Category = null
                }    
            );


            // map navigation properties
            modelBuilder.Entity<Content>().Navigation(c => c.Category).AutoInclude();
            modelBuilder.Entity<Category>().Navigation(c => c.PostedContent).AutoInclude();
        }
    }
}
