using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Art_gallery.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
        public User()
        {
            Posts = new List<Post>();
            Comments = new List<Comment>();
        }
    }

}
