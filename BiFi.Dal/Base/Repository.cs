using BiFi.Dal.Interfaces;
using BiFi.Project.Common.Enums;
using BiFi.Project.Common.Functions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BiFi.Dal.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;//
        private readonly DbSet<T> _dbSet;
        public Repository(DbContext context)//Gelecek entity'e göre işlem yapacak
        {
            if (context == null) return;// If there is no context, let's check and continue
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Insert(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;// To be added as a new entry.
        }
        public void Insert(IEnumerable<T> entites)
        {
            foreach (var entity in entites)
                _context.Entry(entity).State = EntityState.Added;
        }
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Update(T entity, IEnumerable<string> fields)
        {
            _dbSet.Attach(entity);
            var entry = _context.Entry(entity);
            foreach (var field in fields)
                entry.Property(field).IsModified = true;
        }

        public void Update(IEnumerable<T> entites)
        {
            foreach (var entity in entites)
                _context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(IEnumerable<T> entites)
        {
            foreach (var entity in entites)
                _context.Entry(entity).State = EntityState.Deleted;
        }
        public TResult Find<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector)
        {
            return filter == null ? _dbSet.Select(selector).FirstOrDefault() : _dbSet.Where(filter).Select(selector).FirstOrDefault();
        }
        public IQueryable<TResult> Select<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector)
        {
            return filter == null ? _dbSet.Select(selector) : _dbSet.Where(filter).Select(selector);
        }

        public string NewDefaultCode(RecordType recordType, Expression<Func<T, string>> filter, Expression<Func<T, bool>> where = null)
        {
            string DefaultCode()// No records in database
            {
                string code = null;
                var codeSequence = recordType.ToName().Split(' ');
                for (int i = 0; i < codeSequence.Length - 1; i++)
                {
                    code += codeSequence[i];
                    if (i + 1 < codeSequence.Length - 1)
                        code += " ";
                }
                return code += "-0001";
            }
            string NewDefaultCode(string code)// If there is a record in the database
            {
                var numericalValue = "";
                foreach (var karakter in code)
                {
                    if (char.IsDigit(karakter))
                        numericalValue += karakter;
                    else
                        numericalValue = "";
                }
                var afterValueIncrease = (int.Parse(numericalValue) + 1).ToString();
                var difference = code.Length - afterValueIncrease.Length;
                if (difference < 0)
                    difference = 0;
                var newValue = code.Substring(0, difference);
                newValue += afterValueIncrease;//Okul-00|50
                return newValue;
            }
            var maxCode = where == null ? _dbSet.Max(filter) : _dbSet.Where(where).Max(filter);
            return maxCode == null ? DefaultCode() : NewDefaultCode(maxCode);// don't register If you run the default code blog, run newdefault id.
        }
        #region IDisposable
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
