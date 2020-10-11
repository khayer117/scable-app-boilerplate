using System.ComponentModel.DataAnnotations.Schema;

namespace Sab.Domain.Product
{
    [Table("TagProducts")]
    public class TagProduct
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public string TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
