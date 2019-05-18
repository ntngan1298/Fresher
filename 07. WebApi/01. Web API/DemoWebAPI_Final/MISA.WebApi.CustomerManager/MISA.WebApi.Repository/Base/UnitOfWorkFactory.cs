using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebApi.Repository
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private IDatabaseContextFactory _factory;
        private IDatabaseContext _context;
        public SqlTransaction Transaction { get; private set; }

        public UnitOfWork(IDatabaseContextFactory factory)
        {
            _factory = factory;
        }

        public void Commit()
        {
            if (Transaction != null)
            {
                try
                {
                    Transaction.Commit();
                }
                catch (Exception)
                {
                    Transaction.Rollback();
                }
                Transaction.Dispose();
                Transaction = null;
            }
            else
            {
                throw new NullReferenceException("Tryed commit not opened transaction");
            }
        }

        /// <summary>
        /// Define a property of context class
        /// </summary>
        public IDatabaseContext DataContext
        {
            get { return _context ?? (_context = _factory.Context()); }
        }

        /// <summary>
        /// Begin a database transaction
        /// </summary>
        /// <returns>Transaction</returns>
        public SqlTransaction BeginTransaction()
        {
            if (Transaction != null)
            {
                throw new NullReferenceException("Not finished previous transaction");
            }
            Transaction = _context.Connection.BeginTransaction();
            return Transaction;
        }


        public void Dispose()
        {
            if (Transaction != null)
            {
                Transaction.Dispose();
            }
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
