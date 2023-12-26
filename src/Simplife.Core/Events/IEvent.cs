﻿namespace Simplife.Core.Events
{
    public interface IEvent
    {
        public string AggregateId { get; }

        public DateTimeOffset OccurredAt { get; }
    }
}
