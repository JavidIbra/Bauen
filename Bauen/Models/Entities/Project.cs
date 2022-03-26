using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bauen.Models.Entities
{
    public class Project : BaseEntity
    {
        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        public DateTime Date { get; set; }

        [Required]
        [StringLength(2500)]
        public string Text { get; set; }

        [Required]
        [StringLength(150)]
        public string Location { get; set; }

        [Required]
        [StringLength(150)]
        public string Company { get; set; }
        public string Image { get; set; }

        public List<ProjectImage> ProjectImages { get; set; }

        [NotMapped]
        public IFormFile img { get; set; }

        [NotMapped]
        public IFormFile[] ImgList{ get; set; }

    }
}
