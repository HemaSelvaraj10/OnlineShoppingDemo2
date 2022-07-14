using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingDemo2.Models
{
    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }
        [Key]
        public int CateId { get; set; }
        [Required]
        [StringLength(100,MinimumLength =1)]
        public string CateName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}