using System;
using System.Linq;

namespace BiFi.Dal.Interfaces
{
    public interface IUnitOfWork<T> : IDisposable where T : class// Repository response from the database will provide the transfer.
    {
        IRepository<T> Rep { get; }
        bool Save();
    }
}