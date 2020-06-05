using System;
using System.Threading;
using System.Threading.Tasks;
using Marten;
using Marten.Linq;

namespace TodoApi.DataAccess
{
    public class Repository <T> : IRepository<T>
    {
        private readonly IDocumentStore _documentStore;
        public Repository(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }
      
        public IMartenQueryable<T> GetQueryAsync(CancellationToken cancellationToken)
        {
            using (var session  = _documentStore.QuerySession())
            {
                return session.Query<T>();
            }
        }

        public async Task<T> GetByIdAsync(Guid id, CancellationToken token)
        {
            using (var session = _documentStore.QuerySession())
            {
                return await session.LoadAsync<T>(id, token);
            }
        }

        public async Task CreateAsync(T document, CancellationToken cancellationToken)
        {
            using (var session = _documentStore.LightweightSession())
            {
                session.Store(document);
                await session.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
