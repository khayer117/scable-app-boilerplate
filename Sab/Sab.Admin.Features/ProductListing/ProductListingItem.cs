using Sab.Infrastructure.Enum;

namespace Sab.Admin.Features.ProductListing
{
    public class ProductListingItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Discount { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}
