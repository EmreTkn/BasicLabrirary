using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.Dtos
{
    public class CommentDto
    {
        public int BookId { get; set; }
        public string CommentDescription { get; set; }
    }
}
