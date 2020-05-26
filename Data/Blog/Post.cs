using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalSite_ASP.Data.Blog
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime TimePosted { get; set; }
        public DateTime TimeEdited { get; set; }
        
        public Post(string title, string body)
        {
            this.Title = title;
            this.Body = body;
        }
        public Post()
        {

        }

    }
}
