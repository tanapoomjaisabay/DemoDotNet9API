using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.DataAccess.Interfaces
{
    public interface CustomerInfoDataSet
    {
        DbSet<CustomerMasterInfoEntity> custMasterInfoEntity { get; }
    }
}
