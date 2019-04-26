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
    public class CountryBll : BaseBll<Country, ProjectContext>, IBaseCommonBll
    {
        public CountryBll() { }
        public CountryBll(Control ctrl) : base(ctrl) { }
        public BaseEntity Single(Expression<Func<Country, bool>> filter)
        {
            return BaseSingle(filter, x =>x);
        }
        public IEnumerable<BaseEntity> List(Expression<Func<Country, bool>> filter)
        {
            return BaseList(filter, x => x).OrderBy(x => x.DefaultCode).ToList();
        }
        public bool Insert(BaseEntity entity, Expression<Func<Country, bool>> filter)
        {
            return BaseInsert(entity,filter);
        }
        public bool Update(BaseEntity oldEntity, BaseEntity currentEntity, Expression<Func<Country, bool>> filter)
        {
            return BaseUpdate(oldEntity, currentEntity,filter);
        }
        public bool Delete(BaseEntity entity)
        {
            return BaseDelete(entity, RecordType.Country);
        }
        public string NewDefaultCode(Expression<Func<Country, bool>> filter)
        {
            return BaseNewDefaultCode(RecordType.Country, x => x.DefaultCode,filter);
        }
    }
}