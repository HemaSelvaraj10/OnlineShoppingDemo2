using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingDemo2.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150,MinimumLength =1)]
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }

        public decimal Price { get; set; }

        public int CateId { get; set; }
        [ForeignKey("CateId")]
        public virtual Category Categories { get; set; }
    }
}