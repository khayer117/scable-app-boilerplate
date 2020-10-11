using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sab.Domain.Product
{
    [Table("SubCategories")]
    public class SubCategory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubCategoryId { get; set; }
        [Required,MaxLength(100)]
        public string Title { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
