using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Service
{
    public interface ITodoService
    {
        Task<IReadOnlyList<TodoItem>> GetAsync(string name, CancellationToken token);

        Task<IReadOnlyList<TodoItem>> GetById(Guid id, CancellationToken token);

        Task CreateAsync(TodoItem item, CancellationToken token);
    }
}
