using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sab.Domain.Product
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        public string TabId { get; set; }
        
        public ICollection<TagProduct> TagProducts { get; set; }
    }
}
