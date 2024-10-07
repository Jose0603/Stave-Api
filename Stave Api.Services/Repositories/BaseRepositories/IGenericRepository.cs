﻿using System.Linq.Expressions;

namespace Stave_Api.Services.Repositories.BaseRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllInclude(string includeProperties);
        IQueryable<T> FindQueryable(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);
        Task<List<T>> FindListAsync(Expression<Func<T, bool>>? expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            CancellationToken cancellationToken = default);
        Task<List<T>> FindAllAsync(CancellationToken cancellationToken);
        Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, string includeProperties);
        T Add(T entity);
        void AddRange(List<T> entity);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteRange(List<T> entity);
        void SaveChanges();
    }
}
