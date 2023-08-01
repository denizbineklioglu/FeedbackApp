using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Infrastructure.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetAsync(int id);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);

        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetWithFilter(Expression<Func<T, bool>> filter);
    }
}
