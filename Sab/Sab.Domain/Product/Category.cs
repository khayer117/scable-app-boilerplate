using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sab.Domain.Product
{
    [Table("Categories")]
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [MaxLength(100)]
        [Required]
        public string Title { get; set; }

        public IEnumerable<SubCategory> SubCategories { get; set; }
    }
}
