using Bauen.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bauen.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<Banner> banners { get; set; }
        public About about { get; set; }
        public List<Project> projects { get; set; }
 
    }
}
