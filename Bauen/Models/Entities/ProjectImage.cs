using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bauen.Models.Entities
{
    public class ProjectImage : BaseEntity
    {
        public string Image { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
