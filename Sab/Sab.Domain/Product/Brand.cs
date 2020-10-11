using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sab.Domain.Product
{
    [Table("Brands")]
    public class Brand
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; }
        [Required, MaxLength(200)]
        public string Title { get; set; }
        public ICollection<Product> Products { get; set; }
        
    }
}
