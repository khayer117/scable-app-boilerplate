using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sab.Domain.Product
{
    [Table("Products")]
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }

        public ICollection<TagProduct> TagProducts { get; set; }
    }
}
