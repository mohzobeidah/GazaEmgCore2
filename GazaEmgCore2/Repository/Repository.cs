﻿using GazaEmgCore2.Data;
using GazaEmgCore2.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GazaEmgCore2.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationContext Context;
        public Repository(ApplicationContext context)
        {
            Context = context;
        }
        public async Task<TEntity> FindAsync(object id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public TEntity Find(object id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public IQueryable<TEntity> GetAllQuerable()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).AsQueryable();
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            return await Context.SaveChangesAsync();
        }

        public int Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            return Context.SaveChanges();
        }

        public async Task<int> AddAndLogAsync(TEntity entity, string userId)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            //Context.TruncateStringForChangedEntities();
            return await Context.SaveChangesAsync(userId);
        }

        public async Task<int> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
            return await Context.SaveChangesAsync();
        }

        public async Task<int> AddRangeAndLogAsync(IEnumerable<TEntity> entities, string userId)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
            return await Context.SaveChangesAsync(userId);
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
            return await Context.SaveChangesAsync();
        }

        public async Task<int> UpdateAndLogAsync(TEntity entity, string userId)
        {
            Context.Set<TEntity>().Update(entity);
            return await Context.SaveChangesAsync(userId);
        }

        public async Task<int> UpdateRangeAsync(IEnumerable<TEntity> entity)
        {
            Context.Set<TEntity>().UpdateRange(entity);
            return await Context.SaveChangesAsync();
        }

        public async Task<int> UpdateRangeAndLogAsync(IEnumerable<TEntity> entity, string userId)
        {
            Context.Set<TEntity>().UpdateRange(entity);
            return await Context.SaveChangesAsync(userId);
        }


        public async Task<int> RemoveAsync(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            return await Context.SaveChangesAsync();
        }

        public async Task<int> RemoveAndLogAsync(TEntity entity, string userId)
        {
            Context.Set<TEntity>().Remove(entity);
            return await Context.SaveChangesAsync(userId);
        }

        public async Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
            return await Context.SaveChangesAsync();
        }

        public async Task<int> RemoveRangeAndLogAsync(IEnumerable<TEntity> entities, string userId)
        {
            Context.Set<TEntity>().RemoveRange(entities);
            return await Context.SaveChangesAsync(userId);
        }

        public int Count()
        {
            return Context.Set<TEntity>().Count();
        }


    }
}
