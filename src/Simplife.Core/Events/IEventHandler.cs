﻿using Simplife.Domain.Events;

namespace Simplife.Core.Events
{
    public interface IEventHandler<TEvent> where TEvent : IEvent
    {
        void Handle(TEvent @event);
    }
}
