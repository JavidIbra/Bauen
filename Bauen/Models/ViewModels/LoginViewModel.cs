using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bauen.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required, MaxLength(100)]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public bool KeepMeLoggedIn { get; set; }
    }
}
