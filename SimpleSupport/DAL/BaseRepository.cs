using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimpleSupport.DAL
{
    // The following class was created by combining suggests from the following pages
    // https://code.msdn.microsoft.com/Repository-Pattern-in-MVC5-0bf41cd0
    // http://stackoverflow.com/questions/16944527/is-it-possible-to-create-a-generic-method-for-adding-items-to-a-entity-framework
    // where db is the DbContext object itself. The where T : class fixes that error about reference types. Without it,
    // you could pass any type in as T, including bool or struct, or any value type, which DbSet.Add() can't handle.
    // The where specifies that T must be a class, which is a reference type, and therefore allowed.

    // Use a BaseRepository
    // http://codereview.stackexchange.com/questions/27598/following-repository-pattern-properly
    // ~TODO~ Add Erorr checking
    // ~TODO~ Add Error logging
    public class BaseRepository<T> where T : class
    {
        private readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BaseRepository()
        {
        }

        /// <summary>
        /// Add/Insert an entity to the database
        /// </summary>
        /// <param name="newItem">Any class in the context passed to the constructor.</param>
        public async Task AddAsync(T newItem)
        {
            _dbContext.Set<T>().Add(newItem);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Remove/Delete an entity from the database
        /// </summary>
        /// <param name="entity">Any class in the context passed to the constructor.</param>
        public async Task RemoveAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an entity that already exists in the database
        /// </summary>
        /// <param name="entity">Any class in the context passed to the constructor.</param>
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}