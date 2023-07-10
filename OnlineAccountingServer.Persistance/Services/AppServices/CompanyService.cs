﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineAccountingServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineAccountingServer.Application.Services.AppServices;
using OnlineAccountingServer.Domain.AppEntities;
using OnlineAccountingServer.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAccountingServer.Persistance.Services.AppServices
{
    public sealed class CompanyService : ICompanyService
    {
        private static readonly Func<AppDbContext, string, Task<Company?>>
            GetCompanyByNameCompiled =
            EF.CompileAsyncQuery((AppDbContext context, string name) =>
            context.Set<Company>().FirstOrDefault(p => p.Name == name));

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CompanyService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //"Set<Company>()" ifadesi kullanılmasının nedeni, veritabanında "Company" sınıfına karşılık gelen
        //bir tabloyu hedeflemek ve bu tabloya veri eklemektir. Yani, "_context" üzerinden "Set<T>()" metodunu
        //kullanarakbelirli bir tabloya erişim sağlayabilir ve veri ekleme, güncelleme veya silme gibi
        //işlemleri gerçekleştirebilirsiniz.
        public async Task CreateCompany(CreateCompanyRequest request)
        {
            Company company=_mapper.Map<Company>(request);
            company.Id = Guid.NewGuid().ToString();
            await _context.Set<Company>().AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task<Company?> GetCompanyByName(string name)
        {
            return await GetCompanyByNameCompiled(_context,name);
        }
    }
}
