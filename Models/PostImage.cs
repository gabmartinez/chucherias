using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace konoha.Models
{
    public class PostImage
    {

        [Key]
        public int PostImageID { get; set; }

        public string ImagePath { get; set; }

    }
}
