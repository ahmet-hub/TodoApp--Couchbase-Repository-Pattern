using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Dal
{
    public interface IRepository<T>
    {
        Task<Response<IEnumerable<T>>> GetAllAsync();
        Task<Response<IEnumerable<T>>> QueryAsync(Expression<Func<T, bool>> predicate = null);
        Task<Response<T>> GetAsync(string id);
        Task<Response<T>> CreateAsync(T data);
        Task<Response<T>> UpdateAsync(T data);
        Task<Response<T>> DeleteAsync(string id);
    }
}
