using System;
using Marten;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoApi.DataAccess;
using TodoApi.Models;

namespace TodoApi.Service
{
    public class TodoService : ITodoService
    {
        private readonly IRepository<TodoItem> _repository;
        public TodoService(IRepository<TodoItem> repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<TodoItem>> GetAsync(string name, CancellationToken token)
        {
            var result = new List<TodoItem>();
            foreach (var e in Enumerable.Range(0,5))
            {
                var temp = await _repository.GetQueryAsync(token).Where(q => q.Name == name).ToListAsync(token);
                result.AddRange(temp);
            }

            return result;
        }

        public async Task<IReadOnlyList<TodoItem>> GetById(Guid id, CancellationToken token)
        {
            var result = new List<TodoItem>();
            foreach (var e in Enumerable.Range(0, 5))
            {
                var temp = await _repository.GetByIdAsync(id,token);
                result.Add(temp);
            }

            return result;
        }

        public async Task CreateAsync(TodoItem item, CancellationToken token)
        {
            await _repository.CreateAsync(item, token);
        }
    }
}
