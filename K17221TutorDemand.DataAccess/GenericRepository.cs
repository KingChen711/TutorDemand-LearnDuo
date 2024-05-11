using K17221TutorDemand.DataAccess.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace K17221TutorDemand.DataAccess
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected TutorDemandDbContext Context;

        protected GenericRepository(TutorDemandDbContext context)
            => Context = context;

        public IQueryable<T> FindAll(bool trackChanges) => Context.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges
                ? Context.Set<T>()
                    .Where(expression)
                    .AsNoTracking()
                : Context.Set<T>()
                    .Where(expression);

        public void Create(T entity) => Context.Set<T>().Add(entity);

        public void Update(T entity) => Context.Set<T>().Update(entity);

        public void Delete(T entity) => Context.Set<T>().Remove(entity);

        public void CreateMany(IEnumerable<T> entities) => Context.Set<T>().AddRange(entities);

        public void UpdateMany(IEnumerable<T> entities) => Context.Set<T>().UpdateRange(entities);

        public void DeleteMany(IEnumerable<T> entities) => Context.Set<T>().RemoveRange(entities);

        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression) => Context.Set<T>().AnyAsync(expression);
    }
}