using System.Configuration;
using System.Data;
using System.Data.Common;

namespace agit.HTM.Domain
{
    public abstract class DbContext
    {
        protected IDbConnection _connection;
        protected IDbTransaction _transaction;

        protected DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");

        public DbContext()
        {
            _connection = factory.CreateConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        }

        public DbContext(bool UseTransaction = false)
        {
            _connection = factory.CreateConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
            if (UseTransaction)
            {
                _connection.Open();
                _transaction = _connection.BeginTransaction();
            }
        }

        protected bool _disposed;

        public void Commit()
        {

            if (_transaction == null)
                return;
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                resetRepositories();
            }
        }

        public virtual void resetRepositories()
        {
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~DbContext()
        {
            dispose(false);
        }
    }
}
