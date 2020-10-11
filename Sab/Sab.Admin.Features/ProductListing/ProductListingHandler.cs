using Microsoft.Extensions.Logging;
using Sab.Infrastructure;
using System.Threading.Tasks;


namespace Sab.Admin.Features.ProductListing
{
    public class ProductListingHandler : ICommandHandler<ProductListingCommand , NoCommandResult>
    {
        private ILogger<ProductListingHandler> _logger;

        public ProductListingHandler(
            ILogger<ProductListingHandler> logger
            )
        {
            _logger = logger;
        }
        public async Task<NoCommandResult> Handle(ProductListingCommand command)
        {
            this._logger.LogInformation($"Product listing Handler : {command.ProductCategory}");

            return await Task.FromResult(NoCommandResult.Instance);
        }
    }
}
