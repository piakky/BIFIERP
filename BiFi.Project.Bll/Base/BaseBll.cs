using BiFi.Dal.Interfaces;
using BiFi.Project.Bll.Functions;
using BiFi.Project.Bll.Interfaces;
using BiFi.Project.Common.Enums;
using BiFi.Project.Common.Functions;
using BiFi.Project.Common.Messages;
using BiFi.Project.Model.Entities.Base;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace BiFi.Project.Bll.Base
{
    public class BaseBll<T, TContext> : IBaseBll where T : BaseEntity where TContext : DbContext
    {
        private readonly Control _ctrl;
        private IUnitOfWork<T> _uow;// take the instance and assign it to the local variable in order to do the registration.
// bll layer; We will send the data from the DAL layer to the UOW layer.
        protected BaseBll() { }

        protected BaseBll(Control ctrl)
        {
            _ctrl = ctrl;
        }
        // Fields to use for data processing.
        protected TResult BaseSingle<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector)// To bring single record in TResult type.
        {
            GeneralFunctions.CreateUnitIOfWork<T, TContext>(ref _uow);// create unitofwork instanse
            return _uow.Rep.Find(filter, selector);
        }
        protected IQueryable<TResult> BaseList<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector)// To register a TResult type list.
        {
            GeneralFunctions.CreateUnitIOfWork<T, TContext>(ref _uow);
            return _uow.Rep.Select(filter, selector);
        }
        protected bool BaseInsert(BaseEntity entity, params Expression<Func<T, bool>>[] filter)
        {
            GeneralFunctions.CreateUnitIOfWork<T, TContext>(ref _uow);
            _uow.Rep.Insert(entity.EntityConvert<T>());
            return _uow.Save();
        }
        protected bool BaseUpdate(BaseEntity oldEntity, BaseEntity currentEntity, Expression<Func<T, bool>> filter)
        {
            GeneralFunctions.CreateUnitIOfWork<T, TContext>(ref _uow);
            var variableAreas = oldEntity.VariableFieldsSelect(currentEntity);
            if (variableAreas.Count == 0) return true;// do not update if there is no changing field
            _uow.Rep.Update(currentEntity.EntityConvert<T>(), variableAreas);
            return _uow.Save();
        }
        protected bool BaseDelete(BaseEntity entity, RecordType recordType, bool showMessage = true)
        {
            GeneralFunctions.CreateUnitIOfWork<T, TContext>(ref _uow);
            if (showMessage)
                if (Messages.DeleteMessage(recordType.ToName()) != DialogResult.Yes) return false;// user does not say yes we are returning false
            _uow.Rep.Delete(entity.EntityConvert<T>());// if it is already deleted, convert an entity and delete it
            return _uow.Save();
        }
        protected string BaseNewDefaultCode(RecordType recordType, Expression<Func<T, string>> filter, Expression<Func<T, bool>> where = null)
        {
            GeneralFunctions.CreateUnitIOfWork<T, TContext>(ref _uow);
            return _uow.Rep.NewDefaultCode(recordType, filter, where);
        }
        #region IDisposable

        public void Dispose()
        {
            _ctrl?.Dispose();//control null değilse dispose ediyoruz
            _uow?.Dispose();//aynı şekilde unitofwork null değilse dispose ediyoruz.
        }
        #endregion
    }
}
