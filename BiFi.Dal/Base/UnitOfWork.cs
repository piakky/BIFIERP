using BiFi.Dal.Interfaces;
using BiFi.Project.Common.Messages;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;

namespace BiFi.Dal.Base
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly DbContext _context;
        public UnitOfWork(DbContext context)
        {
            if (context == null) return;
            _context = context;
        }
        public IRepository<T> Rep => new Repository<T>(_context);
        public bool Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var sqlEx = (SqlException)ex.InnerException?.InnerException;
                if (sqlEx == null)
                {
                    Messages.ErrorMessage(ex.Message);
                    return false;
                }
                switch (sqlEx.Number)
                {
                    case 208:
                        Messages.ErrorMessage("The table you want to process is not found in the database!");
                        break;
                    case 547:
                        Messages.ErrorMessage("The selected card has processed transactions.");
                        break;
                    case 2601:
                    case 2627:
                        Messages.ErrorMessage("The ID you have entered has been used before!");
                        break;
                    case 4060:
                        Messages.ErrorMessage("Database not found on the server!");
                        break;
                    case 18456:
                        Messages.ErrorMessage("Unable to connect to server, username and (or) password is incorrect!");
                        break;
                    default:
                        Messages.ErrorMessage(sqlEx.Message);
                        break;
                }
                return false;
            }
            catch (Exception ex)
            {
                Messages.ErrorMessage(ex.Message);
                return false;
            }
            return true;
        }
        #region Dispose
        private bool _disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
        #endregion
    }
}