using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KitchenHeaven.FrameWork.DataAccess.Interfaces
{
    public interface IDbContext
    {
        IDbConnection DbConnection { get; }
        IDbTransaction DbTransaction { get; }
    }
}
