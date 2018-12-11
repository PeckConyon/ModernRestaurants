using JobSchedule.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSchedule.Context.Repositories.BaseRepository
{
    /// <summary>
    /// Generic Type of Repository which contains only 
    /// Generic features of a memory object
    /// 
    /// No Update or Saving included since these are not 
    /// Genric type of feautures
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity:BaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> RemoveAsync(TEntity entity);

        Task<TEntity>  GetAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<bool> IsExist(int id);

      

        /* 
  * Changed as the related SaveChangesAsync is moved to UnitOfWork
  * and SavingChanges will be handled asynchronizly there

  Task<TEntity> AddAsync(TEntity entity);

  Task<TEntity> RemoveAsync(TEntity entity);

  */
        //void Add(TEntity entity);

        //void Remove(TEntity entity);


    }
}
