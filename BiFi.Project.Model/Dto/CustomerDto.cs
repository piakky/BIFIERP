using BiFi.Project.Model.Entities;
using BiFi.Project.Model.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiFi.Project.Model.Dto
{
    [NotMapped]
    public class CustomerS:Customer
    {
        //We need to create a data transfer object to receive future data as id!
        public string ProvinceName { get; set; }
        public string CountryName { get; set; }
    }
    public class CustomerL : BaseEntity
    {
        public string NameSurname { get; set; }
        public string IdentificationNumber { get; set; }
        public string TaxNumber { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string EMailAddress { get; set; }
        public string ProvinceName { get; set; }
        public string CountryName { get; set; }
        public string Address { get; set; }
        public int RiskStatus { get; set; }
        public string Description { get; set; }
    }
}
