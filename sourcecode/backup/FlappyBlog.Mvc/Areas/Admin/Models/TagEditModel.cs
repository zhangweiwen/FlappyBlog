using System.ComponentModel.DataAnnotations;

namespace FlappyBlog.Mvc.Areas.Admin.Models
{
    public sealed class TagEditModel
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}