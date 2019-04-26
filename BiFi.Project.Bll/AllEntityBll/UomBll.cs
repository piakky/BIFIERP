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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiFi.Project.Bll.AllEntityBll
{
    public class UomBll : BaseBll<Uom, ProjectContext>, IBaseGeneralBll, IBaseCommonBll
    {
        public UomBll() { }
        public UomBll(Control ctrl) : base(ctrl) { } //to send LayoutControl 
        public BaseEntity Single(Expression<Func<Uom, bool>> filter) //to pull single data
        {
            return BaseSingle(filter, x => x);
        }
        public IEnumerable<BaseEntity> List(Expression<Func<Uom, bool>> filter) //to do listing
        {
            return BaseList(filter, x => x).OrderBy(x => x.DefaultCode).ToList();
        }


        public bool Delete(BaseEntity entity)
        {
            return BaseDelete(entity, RecordType.Uom);
        }

        public bool Insert(BaseEntity entity)
        {
            return BaseInsert(entity, x => x.DefaultCode == entity.DefaultCode);
        }

        public string NewDefaultCode()
        {
            return BaseNewDefaultCode(RecordType.Uom, x => x.DefaultCode);
        }

        public bool Update(BaseEntity oldEntity, BaseEntity currentEntity)
        {
            return BaseUpdate(oldEntity, currentEntity, x => x.DefaultCode == currentEntity.DefaultCode);
        }
    }
}
