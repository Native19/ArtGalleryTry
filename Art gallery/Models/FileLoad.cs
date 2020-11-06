using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Art_gallery.Models
{
    public class FileLoad
    {
        [BindProperty(Name = "file")]
        public IFormFile File { get; set; }
        [BindProperty(Name = "AreChecked")]
        public List<string> AreChecked { get; set; }
    }
}
