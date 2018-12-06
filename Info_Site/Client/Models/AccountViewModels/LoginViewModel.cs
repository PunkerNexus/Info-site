using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required (ErrorMessage = "Вы не ввели Email!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required (ErrorMessage = "Вы не ввели пароль!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }
    }
}
