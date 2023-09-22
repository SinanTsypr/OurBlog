using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace OurBlog.Data
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext db, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            var adminEmail = "admin@example.com";
            var adminPass = "P@ssword1";
            var adminRoleName = "Administrator";

            if (await userManager.Users.AnyAsync(x => x.UserName == adminEmail) || 
                await roleManager.RoleExistsAsync(adminRoleName))
                return;

            var adminUser = new IdentityUser()
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };

            await userManager.CreateAsync(adminUser, adminPass);
            await roleManager.CreateAsync(new IdentityRole(adminRoleName));
            await userManager.AddToRoleAsync(adminUser, adminRoleName);

            List<Post> posts = new List<Post>
            {
                new Post
                {
                    Title = "Captivated by the Dance of the Northern Lights",
                    Content = "A mesmerizing display of colors across the Arctic skies. Nature's masterpiece at its finest.",
                    Image = "1.jpg",
                    AuthorId = adminUser.Id
                },
                new Post
                {
                    Title = "Love Sealed with a Furry Paw",
                    Content = "Two hearts, one journey. Celebrating the engagement of a couple with their loyal companion by their side.",
                    Image = "2.jpg",
                    AuthorId = adminUser.Id
                },
                new Post
                {
                    Title = "Redefining Strength: Conquering the Weight Room",
                    Content = "Determination knows no bounds. Witnessing a man's dedication as he lifts his aspirations along with the weights.",
                    Image = "3.jpg",
                    AuthorId = adminUser.Id
                }
            };

            db.AddRange(posts);
            db.SaveChanges();
        }
    }
}
