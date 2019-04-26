using BiFi.Project.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiFi.Project.Model.Entities
{
    public class Customer:BaseStatusEntity//Id,DefaultId ve Status add
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string DefaultCode { get; set; }

        [Required, StringLength(100)]
        public string NameSurname { get; set; }
        [StringLength(17)]
        public string IdentificationNumber { get; set; }
        [StringLength(17)]
        public string TaxNumber { get; set; }
        [Required, StringLength(17)]
        public string Telephone1 { get; set; }
        [StringLength(17)]
        public string Telephone2 { get; set; }
        [StringLength(100)]
        public string EMailAddress { get; set; }
        public long ProvinceId { get; set; }
        public long CountryId { get; set; }
        [StringLength(250)]
        public string Address { get; set; }
        public int RiskStatus { get; set; }
        public bool CampaignSms { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        public Province Province { get; set; }
        public Country Country { get; set; }
    }
}