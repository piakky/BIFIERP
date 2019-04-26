using BiFi.Project.Model.Entities.Base;
using System;
using System.Linq;

namespace BiFi.Project.Bll.Interfaces
{
    public interface IBaseGeneralBll
    {
        bool Insert(BaseEntity entity);
        bool Update(BaseEntity oldEntity, BaseEntity currentEntity);
        string NewDefaultCode();
    }
}