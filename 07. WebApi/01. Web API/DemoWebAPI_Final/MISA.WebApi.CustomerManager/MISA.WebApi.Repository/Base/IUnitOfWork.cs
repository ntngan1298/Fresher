using MISA.WebApi.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebApi.Repository
{
    public interface IUnitOfWork
    {
        IDatabaseContext DataContext { get; }
        SqlTransaction BeginTransaction();
        void Commit();
    }
}
