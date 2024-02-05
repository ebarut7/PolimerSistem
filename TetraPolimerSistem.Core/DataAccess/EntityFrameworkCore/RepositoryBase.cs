using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TetraPolimerSistem.Core.Entities;

namespace TetraPolimerSistem.Core.DataAccess.EntityFrameworkCore
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntity, new()
    {
        DbContext _db;
        DbSet<T> _set;

        public RepositoryBase(DbContext db)
        {
            _db = db;
            _set = _db.Set<T>();
        }

        public async Task AddAsync(T entity) => _set.Add(entity);

        public async Task DeleteAsync(T entity) => _set.Remove(entity);

        public async Task UpdateAsync(T entity) => _set.Update(entity);

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null) => expression is not null ? _set.Where(expression).ToList() : _set.ToList();

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression) => await _set.FirstOrDefaultAsync(expression);

        public async Task<int> SaveAsync() => await _db.SaveChangesAsync();


    }
}
