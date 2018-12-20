using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models.PostViewModels
{
    public class VideoViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Url { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Name { get; set; }

        public DateTime PostedOn { get; set; }
    }
}
