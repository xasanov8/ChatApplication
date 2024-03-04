using ChatApplicationAPI.Application.Abstractions.IRepositories;
using ChatApplicationAPI.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplicationAPI.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ChatApplicationApiDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(ChatApplicationApiDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> Create(T entity)
        {
            var result = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> Delete(Expression<Func<T, bool>> expression)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(expression);
                if (result == null)
                {
                    return false;
                }

                _dbSet.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteMany(Expression<Func<T, bool>> expression)
        {
            try
            {
                var entitiesToDelete = await _dbSet.Where(expression).ToListAsync();
                if(entitiesToDelete.Count  == 0)
                {
                    return false;
                }
                _dbSet.RemoveRange(entitiesToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByAny(Expression<Func<T, bool>> expression)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(expression);
                if (result == null)
                {
                    return null;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetByAll(Expression<Func<T, bool>> expression)
        {
            try
            {
                var result = _dbSet.Select(x => x).Where(expression);
                if (result == null)
                {
                    return null;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<T> Update(T entity)
        {
            var result = _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}
