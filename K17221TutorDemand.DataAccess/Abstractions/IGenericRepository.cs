using System.Linq.Expressions;

namespace K17221TutorDemand.DataAccess.Abstractions;

public interface IGenericRepository<T>
{
    IQueryable<T> FindAll(bool trackChanges);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    void CreateMany(IEnumerable<T> entities);
    void UpdateMany(IEnumerable<T> entities);
    void DeleteMany(IEnumerable<T> entities);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
}