using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineAccountingServer.Domain.Abstractions;
using OnlineAccountingServer.Domain.Repositories;
using OnlineAccountingServer.Persistance.Context;
using OnlineAccountingServer.Persistance.Migrations;

namespace OnlineAccountingServer.Persistance.Repositories
{
    public class QueryRepository<T> : IQueryRepository<T>
        where T : Entity
    {
        private static readonly Func<CompanyDbContext, string,bool, Task<T>> GetByIdCompiled =
            EF.CompileAsyncQuery((CompanyDbContext context, string id,bool isTracking) =>
            isTracking == true ? context.Set<T>().FirstOrDefault(p => p.Id == id):
            context.Set<T>().AsNoTracking().FirstOrDefault(p => p.Id == id));

        private static readonly Func<CompanyDbContext,bool, Task<T>> GetFirstCompiled =
         EF.CompileAsyncQuery((CompanyDbContext context,bool isTracking) =>
        isTracking == true ? context.Set<T>().FirstOrDefault():
         context.Set<T>().AsNoTracking().FirstOrDefault());

        private static readonly Func<CompanyDbContext,bool, Expression<Func<T, bool>>, Task<T>> GetFirstByExpressionCompiled =
       EF.CompileAsyncQuery((CompanyDbContext context, bool isTracking, Expression<Func<T,bool>> expression) =>
           isTracking == true ? context.Set<T>().FirstOrDefault(expression):
       context.Set<T>().AsNoTracking().FirstOrDefault(expression));

        private CompanyDbContext _companyDbContext;
        public DbSet<T> Entity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void SetDbContextInstance(DbContext context)
        {
            _companyDbContext=(CompanyDbContext)context;
            Entity=_companyDbContext.Set<T>();
        }

        public IQueryable<T> GetAll(bool isTracking = true)
        {
            var result = Entity.AsQueryable();
            if (isTracking == false)
            {
                result = result.AsNoTracking();
            }
            return result;
        }

        public async Task<T> GetById(string id, bool isTracking = true)
        {
           return await GetByIdCompiled(_companyDbContext,id,isTracking);
        }

        public async Task<T> GetFirst(bool isTracking = true)
        {
            return await GetFirstCompiled(_companyDbContext,isTracking);
        }

        public async Task<T> GetFirstByExpression(Expression<Func<T, bool>> expression, bool isTracking = true)
        {
            return await GetFirstByExpressionCompiled(_companyDbContext, isTracking,expression);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true)
        {
            var result = Entity.Where(expression);
            if (isTracking == false)
            {
                result = result.AsNoTracking();
            }
            return result;
        }
    }
}
