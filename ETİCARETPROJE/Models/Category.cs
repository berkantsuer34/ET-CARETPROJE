using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ETİCARETPROJE.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        // Kategoriye ait ürünler
        public ICollection<Product> Products { get; set; }
    }
}