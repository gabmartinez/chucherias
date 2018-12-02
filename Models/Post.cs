﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace konoha.Models
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }

        [StringLength(45, ErrorMessage = "The field {0} can contain maximun {1} and minimun {2} chracters")]
        public String Title { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        public int User { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        public int CategoryID { get; set; }

        public Category Category { get; set; }

        [StringLength(100, ErrorMessage = "The field {0} can contain maximun {1} and minimun {2} chracters")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = " Publish date")]
        public DateTime? Publish_date { get; set; }

        [Display(Name = "Is active")]
        public bool IsAcctive { get; set; }


    }
}