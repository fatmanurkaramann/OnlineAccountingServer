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
        private static readonly Func<CompanyDbContext, string, Task<T>> GetByIdCompiled =
            EF.CompileAsyncQuery((CompanyDbContext context, string id) => context.Set<T>().FirstOrDefault(p => p.Id == id));

        private static readonly Func<CompanyDbContext, Task<T>> GetFirstCompiled =
         EF.CompileAsyncQuery((CompanyDbContext context) => context.Set<T>().FirstOrDefault());

        private static readonly Func<CompanyDbContext, Expression<Func<T, bool>>, Task<T>> GetFirstByExpressionCompiled =
       EF.CompileAsyncQuery((CompanyDbContext context,Expression<Func<T,bool>> expression) => 
            context.Set<T>().FirstOrDefault(expression));

        private CompanyDbContext _companyDbContext;
        public DbSet<T> Entity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void SetDbContextInstance(DbContext context)
        {
            _companyDbContext=(CompanyDbContext)context;
            Entity=_companyDbContext.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return Entity.AsQueryable();
        }

        public async Task<T> GetById(string id)
        {
           return await GetByIdCompiled(_companyDbContext,id);
        }

        public async Task<T> GetFirst()
        {
            return await GetFirstCompiled(_companyDbContext);
        }

        public async Task<T> GetFirstByExpression(Expression<Func<T, bool>> expression)
        {
            return await GetFirstByExpressionCompiled(_companyDbContext,expression);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            return Entity.Where(expression);
        }
    }
}
