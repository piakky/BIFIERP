using BiFi.Project.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BiFi.Dal.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class// We know that T is an incoming entity and it is disposable after the transaction, so we don't cover data in memory.
    {
        void Insert(T entity);// Sample Current Card (BaseEditForm) for single records
        void Insert(IEnumerable<T> entites);// Sample Current Cards (BaseListForm)
        void Update(T entity);// Sample Current Card (BaseEditForm) for single records
        void Update(T entity, IEnumerable<string> fields);// When it comes to list type, only current fields (BaseListForm)
        void Update(IEnumerable<T> entites);
        void Delete(T entity);
        void Delete(IEnumerable<T> entites);
        TResult Find<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector);
        IQueryable<TResult> Select<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector);
        string NewDefaultCode(RecordType recordType, Expression<Func<T, string>> filter, Expression<Func<T, bool>> where = null);
    }
}
