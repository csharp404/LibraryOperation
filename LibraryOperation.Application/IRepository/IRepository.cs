using System.Linq.Expressions;

namespace LibraryOperation.Application.IRepository;



    public interface IRepository<T> where T : class
    {
        Task<List<T?>> GetAllAsync(Expression<Func<T, object>>? include=null);

        Task<T?> GetByIdAsync(int id);

        Task<List<T?>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<T, object>>? include);

        Task<bool> CreateAsync(T model);

        Task<List<T?>> FindByConditionAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> includes);
        Task<T?> FindByEmailAsync(Expression<Func<T, bool>> predicate);
        Task<bool> UpdateAsync(object id, T entity);

        Task<bool> DeleteByIdAsync(int id);


    }
