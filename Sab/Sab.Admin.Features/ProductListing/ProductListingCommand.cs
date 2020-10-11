using Sab.Infrastructure.Enum;

namespace Sab.Admin.Features.ProductListing
{
    public class ProductListingCommand
    {
        public ProductCategory ProductCategory { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
