using Sab.Features.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sab.Features.ProductListing
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
