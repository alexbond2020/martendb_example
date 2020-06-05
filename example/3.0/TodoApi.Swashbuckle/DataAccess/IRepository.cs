using System;
using System.Threading;
using System.Threading.Tasks;
using Marten.Linq;

namespace TodoApi.DataAccess
{
    public interface IRepository<T>
    {
        IMartenQueryable<T> GetQueryAsync( CancellationToken cancellationToken);

        Task<T> GetByIdAsync(Guid id, CancellationToken token);

        Task CreateAsync(T document, CancellationToken cancellationToken);
    }
}
