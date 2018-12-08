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

        [Display(Name="Titulo")]
        [Required(ErrorMessage = "Debe digitar el {0}")]
        [StringLength(100, ErrorMessage = "El campo {0} debe contener máximo {1} y mínimo {2} caratecter")]
        public String Title { get; set; }
        
        [StringLength(450)]
        public String UserID { get; set; }

        [Display(Name="Categoria")]
        [Required(ErrorMessage = "Debe digitar el {0}")]
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }

        public bool IsPreferredPost { get; set; }

        [Display(Name="Descripción")]
        [StringLength(250, ErrorMessage = "El campo {0} debe contener máximo {1} y mínimo {2} caratecter")]
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
        
        [Display(Name="Imagenes")]
        public List<PostImage> Images { get; set; }

      
    }
}
