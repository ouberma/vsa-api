using Vertical.Slice.Template.Shared.Abstractions.Caching;
using Vertical.Slice.Template.Shared.Abstractions.Core.CQRS;

namespace Vertical.Slice.Template.Shared.Cache;

public abstract record CacheQuery<TRequest, TResponse> : ICacheQuery<TRequest, TResponse>
    where TRequest : IQuery<TResponse>
    where TResponse : class
{
    public virtual TimeSpan AbsoluteExpirationRelativeToNow => TimeSpan.FromMinutes(5);

    // public virtual TimeSpan SlidingExpiration => TimeSpan.FromSeconds(30);
    // public virtual DateTime? AbsoluteExpiration => null;
    public virtual string Prefix => "Ch_";

    public virtual string CacheKey(TRequest request) => $"{Prefix}{typeof(TRequest).Name}";
}
