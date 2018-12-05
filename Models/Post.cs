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

        [Display(Name="Tittulo")]
        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(45, ErrorMessage = "The field {0} can contain maximun {1} and minimun {2} chracters")]
        public String Title { get; set; }
        
        [StringLength(450)]
        public String UserID { get; set; }

        [Display(Name="Categoria")]
        [Required(ErrorMessage = "You must enter a {0}")]
        public int CategoryID { get; set; }

        public Category Category { get; set; }

        [Display(Name="Descripción")]
        [StringLength(100, ErrorMessage = "The field {0} can contain maximun {1} and minimun {2} chracters")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Publish date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Is active")]
        public bool IsAcctive { get; set; }

        [Display(Name="Precio")]
        [Required]
        [Column(TypeName = "decimal(12, 2)")]
        public decimal Price { get; set; }
        
        // [MaxLength(3)]
        public List<PostImage> Images { get; set; }
    }
}
