using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace konoha.Models
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(45, ErrorMessage = "The field {0} can contain maximun {1} and minimun {2} chracters")]
        public String Title { get; set; }
        
        [StringLength(450)]
        public String UserID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        public int CategoryID { get; set; }

        public Category Category { get; set; }

        [StringLength(100, ErrorMessage = "The field {0} can contain maximun {1} and minimun {2} chracters")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Publish date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Is active")]
        public bool IsAcctive { get; set; }
        
        // [MaxLength(3)]
        public List<PostImage> Images { get; set; }
    }
}
