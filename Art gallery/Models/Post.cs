using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Art_gallery.Models
{
    public class Post
    {
        [Key]
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Path { get; set; }
            public DateTime DateTime { get; set; }
            public int? UserId { get; set; }
            public User User { get; set; }

        public List<Comment> Comments { get; set; }
        public List<PostTag> PostTags { get; set; }

        public Post()
        {
            Comments = new List<Comment>();
            PostTags = new List<PostTag>();
        }

    }
}
