using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bauen.Models.Entities
{
    public class About :BaseEntity
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [Required]
        [StringLength(2000)]
        public string Text { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Img { get; set; }
    }
}
