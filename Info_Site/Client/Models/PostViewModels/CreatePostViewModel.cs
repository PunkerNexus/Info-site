using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models.PostViewModels
{
    public class CreatePostViewModel
    { 
        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string UrlSlug { get; set; }

        public bool Published { get; set; }

        public DateTime PostedOn { get; set; }

        //public DateTime? Modified { get; set; }

        public Category Category { get; set; }
    }
}
