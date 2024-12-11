using assignment_4.Models;
using Microsoft.AspNetCore.Identity;
namespace assignment_4.Data
{
    public static class ApplicationDbInitializer
    {
        public static void Initialize(ApplicationDbContext db, UserManager<ApplicationUser> um, RoleManager<IdentityRole> rm)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var adminRole = new IdentityRole("Admin");
            rm.CreateAsync(adminRole).Wait();
            
            var user1 = new ApplicationUser{UserName = "user1", Email = "user1@mail.com", Nickname = "User1"};
            var user2 = new ApplicationUser{UserName = "user2", Email = "user2@mail.com", Nickname = "User2"};
            var user3 = new ApplicationUser{UserName = "user3", Email = "user3@mail.com", Nickname = "User3"};
            
            um.CreateAsync(user1, "Password1.").Wait();
            um.CreateAsync(user2, "Password1.").Wait();
            um.CreateAsync(user3, "Password1.").Wait();
            
            var blogs = new[]
            {
                new Blog("User1", "Title 1", "Summary for blog 1", "Content for blog 1", DateTime.Now, user1),
                new Blog("User1", "Title 1", "Summary for blog 1", "Content for blog 1", DateTime.Now, user1),
                new Blog("User1", "Title 1", "Summary for blog 1", "Content for blog 1", DateTime.Now, user1)
            };

            db.Blogs.AddRange(blogs);
           
            db.SaveChanges();
        }
    }
}
