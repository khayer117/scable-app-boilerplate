using System;
using System.Threading.Tasks;

namespace Sab.ProductListing.Features.Processors
{
    public interface IServiceExecutor
    {
        Task Execute<TExecutor>(int id) where TExecutor : IBatchProcessor;
    }

    public class ServiceExecutor : IServiceExecutor
    {
        private readonly Func<Type, object> _executorFactory;

        public ServiceExecutor(Func<Type, object> executorFactory)
        {
            _executorFactory = executorFactory;
        }
        public async Task Execute<TExecutor>(int id) where TExecutor : IBatchProcessor
        {
            //var executor1 = this._executorFactory(typeof(TExecutor));
            var executor = (TExecutor)this._executorFactory(typeof(TExecutor));
            await executor.Process(id);
        }
    }
}
