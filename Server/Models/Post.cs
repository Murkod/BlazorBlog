using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Blog.Server.Models
{
    public partial class Post
    {
        [Key]
        public int Id { get; set; }

        public int AuthorID { get; set; }
        public Author Author { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        [StringLength(4000)]
        public string Content { get; set; }

        [StringLength(500)]
        public string Image { get; set; }
    }
}
