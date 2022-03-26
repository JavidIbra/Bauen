using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bauen.Models.Entities
{
    public class Banner : BaseEntity
    {
        [Required]
        [StringLength(150)]
        public string Title { get; set; }
        [Required]
        [StringLength(200)]
        public string Subtitle { get; set; }
        public string Link { get; set; }
        public string LinkText { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Img { get; set; }

    }
}
