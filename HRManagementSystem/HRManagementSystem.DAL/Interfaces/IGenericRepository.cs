using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.DAL.Entities;
using System.Linq.Expressions;

namespace HRManagementSystem.DAL.Repositories.Interfaces;

public interface IGenericRepository<TEntity>
    where TEntity : BaseEntity
{
    Task<TEntity?> GetByIdAsync(int id);

    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

    Task AddAsync(TEntity entity);

    void Update(TEntity entity);

    void Delete(TEntity entity);

    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);


}
