using System;
using System.Threading.Tasks;

namespace Sab.ProductListing.Features.Processors
{
    public interface IBatchProcessor
    {
        Task<bool> Process(int id);
    }

    public interface IProcessorA : IBatchProcessor
    {

    }

    public interface IProcessorB : IBatchProcessor
    {

    }

    public class ProcessorA : IProcessorA
    {
        public async Task<bool> Process(int id)
        {
            Console.WriteLine("Process A");

            return await Task.FromResult(true);
        }
    }

    public class ProcessorB : IProcessorB
    {
        public async Task<bool> Process(int id)
        {
            Console.WriteLine("Process B");

            return await Task.FromResult(true);
        }
    }
}
