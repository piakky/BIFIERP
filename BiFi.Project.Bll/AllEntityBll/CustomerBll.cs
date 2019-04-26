using BiFi.Project.Bll.Base;
using BiFi.Project.Bll.Interfaces;
using BiFi.Project.Common.Enums;
using BiFi.Project.Data.Context;
using BiFi.Project.Model.Dto;
using BiFi.Project.Model.Entities;
using BiFi.Project.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace BiFi.Project.Bll.AllEntityBll
{
    public class CustomerBll : BaseBll<Customer, ProjectContext>,IBaseGeneralBll, IBaseCommonBll
    {
        public CustomerBll() { }
        public CustomerBll(Control ctrl) : base(ctrl) { }
        public BaseEntity Single(Expression<Func<Customer, bool>> filter)
        {
            return BaseSingle(filter, x => new CustomerS
            {
                Id = x.Id,
                DefaultCode = x.DefaultCode,
                NameSurname = x.NameSurname,
                IdentificationNumber = x.IdentificationNumber,
                TaxNumber = x.TaxNumber,
                Telephone1 = x.Telephone1,
                Telephone2 = x.Telephone2,
                EMailAddress = x.EMailAddress,
                ProvinceId = x.ProvinceId,
                ProvinceName = x.Province.ProvinceName,
                CountryId = x.CountryId,
                CountryName = x.Country.CountryName,
                Address = x.Address,
                RiskStatus = x.RiskStatus,
                CampaignSms = x.CampaignSms,
                Description = x.Description,
                Status = x.Status
            });
        }
        public IEnumerable<BaseEntity> List(Expression<Func<Customer, bool>> filter)
        {
            return BaseList(filter, x => new CustomerL
            {
                Id = x.Id,
                DefaultCode = x.DefaultCode,
                NameSurname = x.NameSurname,
                IdentificationNumber = x.IdentificationNumber,
                TaxNumber = x.TaxNumber,
                Telephone1 = x.Telephone1,
                Telephone2 = x.Telephone2,
                EMailAddress = x.EMailAddress,
                ProvinceName = x.Province.ProvinceName,
                CountryName = x.Country.CountryName,
                Address = x.Address,
                RiskStatus = x.RiskStatus,
                Description = x.Description
            }).OrderBy(x => x.DefaultCode).ToList();
        }
        public bool Insert(BaseEntity entity)
        {
            return BaseInsert(entity, x => x.DefaultCode == entity.DefaultCode);
        }
        public bool Update(BaseEntity oldEntity, BaseEntity currentEntity)
        {
            return BaseUpdate(oldEntity, currentEntity, x => x.DefaultCode == currentEntity.DefaultCode);
        }
        public bool Delete(BaseEntity entity)
        {
            return BaseDelete(entity, RecordType.Customer);
        }
        public string NewDefaultCode()
        {
            return BaseNewDefaultCode(RecordType.Customer, x => x.DefaultCode);
        }
    }
}
