using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models.AccountViewModels
{
    public class ProfileViewModel
    {
        [EmailAddress]
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [StringLength(200, ErrorMessage = "Максимум 200 символов!")]
        public string About { get; set; }

        [StringLength(20, ErrorMessage = "Максимум 20 символов!")]
        public string Hobby { get; set; }

        //[Url]
        public string ProfilePhoto { get; set; }

        public string StatusMessage { get; set; }
    }
}
