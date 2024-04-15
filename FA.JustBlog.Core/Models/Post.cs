using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class Post
    {
        // Define model post in here

        [Key]
        public int Id { get; set; }

        public IList<PostTagMap> PostTagMaps { get; set; }
    }
}
