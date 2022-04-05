namespace Product.Application.Bases
{
    public interface IBaseService<TRequest, TResponse, TId>
        where TRequest : IRequest
        where TResponse : IResponse
    {
        Task SaveAsync(TRequest request);
        Task DeleteAsync(TId id);
        Task UpdateAsync(TRequest request);
        Task<TResponse> GetAsync(TId id, CancellationToken cancellationToken);
        Task<IEnumerable<TResponse>> GetAllAsync(CancellationToken cancellationToken);

    }
}
