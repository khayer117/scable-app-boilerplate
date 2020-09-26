﻿namespace Sab.Infrastructure
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICommandBus
    {
        Task<TResult> Send<TResult>(object command, CancellationToken cancellationToken);
    }
}
