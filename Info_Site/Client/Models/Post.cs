﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Post
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string TitleUrl { get; set; }

        //public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string UrlSlug { get; set; } // alternative for the title in address, localhost:1111/archive/some_title

        public bool Published { get; set; }

        public DateTime PostedOn { get; set; }

        public string Author { get; set; }

        //public DateTime? Modified { get; set; }

        public Category Category { get; set; }
    }
}
