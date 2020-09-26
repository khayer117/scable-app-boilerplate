namespace Sab.Infrastructure
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    //using Sab.Infrastructure.Logger;

    public class CommandBus : ICommandBus
    {
        private static readonly Type GenericCommandHandlerType = typeof(ICommandHandler<,>);
        private readonly Func<Type, object> resolver;
        private readonly ILogger logger;

        public CommandBus(Func<Type, object> resolver,
            ILogger<CommandBus> logger)
        {
            this.resolver = resolver;
            this.logger = logger;
        }

        public async Task<TResult> Send<TResult>(object command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            logger.LogInformation($"CommandBus processing {command.GetType().Name} command");

            cancellationToken.ThrowIfCancellationRequested();

            var handlerType = GenericCommandHandlerType.MakeGenericType(command.GetType(), typeof(TResult));
            dynamic handler = this.resolver(handlerType);
            var handlerName = ((Type)handler.GetType()).FullName;

            if (handler == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture,
                    "Unable to find any handler for command \"{0}\"!", command.GetType()));
            }

            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                dynamic result;

                result = await handler.Handle((dynamic)command);
                this.logger.LogInformation($"CommandBus processed command {command.GetType().FullName}");
                
                var disposable = handler as IDisposable;
                disposable?.Dispose();
                return result;
            }
            catch (Exception e)
            {
                logger.LogError(e, "CommandBus- Handler {Handler} generates error.");
                throw;                
            }

        }
    }
}
