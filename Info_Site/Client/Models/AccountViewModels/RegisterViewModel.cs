﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required (ErrorMessage = "Email должен быть введен!")]
        [EmailAddress]
        [Display(Name = "Email")]
        //[Remote("UserExists", "Account", ErrorMessage = "Пользователь с таким именем уже существует.")]
        public string Email { get; set; }

        [Required (ErrorMessage = "Пароль должен быть введен!")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Пароль и подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }
    }
}
