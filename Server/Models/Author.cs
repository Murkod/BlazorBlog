using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Blog.Server.Models
{
    public partial class Author
    {
      

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorID { get; set; }
        [StringLength(50)]
        public string Login { get; set; } = null!;
        [StringLength(100)]
        public string PasswordHash { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime AddTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedAt{ get; set; }
        [StringLength(30)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string LastName { get; set; } = null!;
      

        [InverseProperty("Author")]
        public virtual ICollection<Post> Posts { get; set; }


    }
}
