using Microsoft.EntityFrameworkCore;
using OnlineAccountingServer.Domain;
using OnlineAccountingServer.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAccountingServer.Persistance
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private CompanyDbContext _companyDbContext;
        public void SetDbContextInstance(DbContext dbContext)
        {
            _companyDbContext = (CompanyDbContext)dbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
           int count= await _companyDbContext.SaveChangesAsync();
            return count;
        }
    }
}
