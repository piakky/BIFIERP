using BiFi.Project.Bll.Base;
using BiFi.Project.Bll.Interfaces;
using BiFi.Project.Common.Enums;
using BiFi.Project.Data.Context;
using BiFi.Project.Model.Entities;
using BiFi.Project.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace BiFi.Project.Bll.AllEntityBll
{
    public class AccountBll : BaseBll<Account, ProjectContext>, IBaseGeneralBll, IBaseCommonBll
    {
        //we’ve imported data, now we’re going to go to the other side and multiply the same codes.
        public AccountBll() { } // we create two constructors, the other will take a variable of control type
        public AccountBll(Control ctrl) : base(ctrl) { } //to send LayoutControl 
        public BaseEntity Single(Expression<Func<Account, bool>> filter) //to pull single data
        {
            return BaseSingle(filter, x => x);
        }
        public IEnumerable<BaseEntity> List(Expression<Func<Account, bool>> filter) //to do listing
        {
            return BaseList(filter, x => x).OrderBy(x => x.DefaultCode).ToList();
        }
        public bool Insert(BaseEntity entity) //Data Add
        {
            return BaseInsert(entity, x => x.DefaultCode == entity.DefaultCode);
        }
        public bool Update(BaseEntity oldEntity, BaseEntity currentEntity) //Data Update
        {
            return BaseUpdate(oldEntity, currentEntity, x => x.DefaultCode == currentEntity.DefaultCode);
        }
        public bool Delete(BaseEntity entity) // Data Delete
        {
            return BaseDelete(entity, RecordType.Account);
        }
        public string NewDefaultCode() //DefaultCode-> NewDefaultCode Create
        {
            return BaseNewDefaultCode(RecordType.Account, x => x.DefaultCode);
        }
    }
}