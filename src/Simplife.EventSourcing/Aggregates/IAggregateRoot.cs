﻿
namespace Simplife.Domain.Aggregates
{
    public interface IAggregateRoot<TKey> : Core.Aggregates.IAggregateRoot<TKey>
    {
        public long Version { get; }
    }
}