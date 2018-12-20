using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models.PostViewModels
{
    public class CreatePostViewModel
    { 
        public string Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string TitleUrl { get; set; }

        //public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Description { get; set; }

        public string UrlSlug { get; set; }

        public bool Published { get; set; }

        public string Author { get; set; }

        public DateTime PostedOn { get; set; }

        //public DateTime? Modified { get; set; }

        public Category Category { get; set; }

        public string[] GetAll { get; set; }
    }
}
