using System.ComponentModel.DataAnnotations;

namespace OurBlog.Areas.Admin.Models
{
    public class NewPostViewModel
    {
        [MaxLength(400)]
        public string Title { get; set; } = null!;

        public string? Content { get; set; }

        public IFormFile? PostImage { get; set; }
    }
}
