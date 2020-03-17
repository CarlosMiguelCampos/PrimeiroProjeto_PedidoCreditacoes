﻿using CMA.ISMAI.Engine.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CMA.ISMAI.Engine.Domain.EventHandlers
{
    public class DeployEventHandler : INotificationHandler<DeployCompletedEvent>
    {
        public Task Handle(DeployCompletedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
