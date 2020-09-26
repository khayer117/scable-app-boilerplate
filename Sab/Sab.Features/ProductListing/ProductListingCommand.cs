using Sab.Features.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sab.Features.ProductListing
{
    public class ProductListingCommand
    {
        public ProductCategory ProductCategory { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
