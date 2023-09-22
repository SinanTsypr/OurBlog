using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OurBlog.Data
{
    public class Post
    {
        public int Id { get; set; }

        [MaxLength(400)]
        public string Title { get; set; } = null!;

        public string? Content { get; set; }

        public string? Image { get; set; }

        public string AuthorId { get; set; } = null!;


        public IdentityUser Author { get; set; } = null!;
    }
}
