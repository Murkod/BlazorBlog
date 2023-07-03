using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Shared.Models.DTO.PostDTOS
{
    public class UpdatePostDTO
    {
        public int PostID { get; set; }
        public int AuthorID { get; set; }
        public int CategoryID { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }

}
