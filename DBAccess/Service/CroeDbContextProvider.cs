using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Uow;
using DBAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBAccess.Service
{
    public class CroeDbContextProvider : UnitOfWorkDbContextProvider<CoreDB>
    {
        public CroeDbContextProvider(ICurrentUnitOfWorkProvider currentUnitOfWorkProvider) : base(currentUnitOfWorkProvider)
        {

        }
    }
}
