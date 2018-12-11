
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using JobSchedule.Entities.Models;
using Microsoft.EntityFrameworkCore;
using JobSchedule.Context.Context;


namespace JobSchedule.Context.Repositories.BaseRepository
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity:BaseEntity
    {
        private bool disposed;
        protected readonly DbContext context;

        public Repository(JobDBContext _context) // check on interface later
        {
            this.context = _context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.Entry(entity).State = EntityState.Added;

            await context.SaveChangesAsync().ConfigureAwait(false);
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

            await context.SaveChangesAsync().ConfigureAwait(false);
            return entity;
        }

        public async Task<TEntity> RemoveAsync(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            context.Entry(entity).State = EntityState.Deleted;

            await context.SaveChangesAsync().ConfigureAwait(false);
            return entity;
        }

        public async Task<TEntity> GetAsync(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id).ConfigureAwait(false);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entity = await context.Set<TEntity>().ToListAsync().ConfigureAwait(false);
            return entity;
        }


        public async Task<bool> IsExist(int id)
        {
             return await  context.Set<TEntity>().AnyAsync(e => e.Id == id);
        }


        public void Dispose()
        {
            if(disposed)
            {
                context?.Dispose();
            }
            disposed = true;
        }

    }
}
