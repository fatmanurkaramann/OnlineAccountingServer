﻿using OnlineAccountingServer.Domain.Abstractions;
using OnlineAccountingServer.Domain.CompanyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAccountingServer.Domain.Repositories.UCAFRepositories
{
    public interface IUCAFCommandRepository:ICommandRepository<UniformChartOfAccount>
    {
    }
}
