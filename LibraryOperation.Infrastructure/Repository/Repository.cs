using LibraryOperation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using LibraryOperation.Application.IRepository;
namespace LibraryOperation.Infrastructure.Repository;
    public class Repository<T>(MyDbContext db) : IRepository<T>
        where T : class
    {
        public async Task<List<T>> GetAllAsync(Expression<Func<T, object>>? include = null)
        {
            IQueryable<T> entity = db.Set<T>();
            if (include != null)
            {
                entity = entity.Include(include);
            }
            return await entity.ToListAsync();
        }
        public async Task<T?> GetByIdAsync(int id)
        {
            return await db.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<T, object>>? include)
        {
            IQueryable<T> entities = db.Set<T>();
            if (include != null)
            {
                entities.Include(include);
            }
            return await entities.Skip(pageNumber * pageSize).Take(pageSize).ToListAsync();
        }



        public async Task<bool> CreateAsync(T model)
        {

            await db.Set<T>().AddAsync(model);
           await db.SaveChangesAsync(); 
            return true;
        }

        public async Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>>? predicate, Expression<Func<T, object>>? includes)
        {
            IQueryable<T> entity = db.Set<T>();
            if (predicate != null)
            {
                entity = entity.Where(predicate);
            }

            if (includes != null)
            {
                entity = entity.Include(includes);
            }

            return await entity.ToListAsync();
        }

        public async Task<bool> UpdateAsync(object id, T model)
        {
           
                var existingEntity = await db.FindAsync<T>(id);
                if (existingEntity == null) return false;

                var entry = db.Entry(existingEntity);
                var key = entry.Metadata.FindPrimaryKey();

                
                foreach (var property in entry.Metadata.GetProperties())
                {
                    if (key.Properties.Any(k => k.Name == property.Name))
                        continue; 

                    var newValue = db.Entry(model).Property(property.Name).CurrentValue;
                    entry.Property(property.Name).CurrentValue = newValue;
                }

                await db.SaveChangesAsync();
                return true;
            

        }





    public async Task<bool> DeleteByIdAsync(int id)
        {
            T? entity = await db.Set<T>().FindAsync(id);
            if (entity != null)
            {
                db.Set<T>().Remove(entity);
                await db.SaveChangesAsync();
            return true;
            }
            return false;
        }

    }
