using BiFi.Project.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiFi.Project.Model.Entities
{
    public class Account: BaseStatusEntity// To add Status Column
    {
        [Index("IX_DefaultId", IsUnique = false)]//Adana->#Country-0001,0002,Antalya->#Country-0001,0002 I need to be able to complete the defaultId in style.
        public override string DefaultCode { get; set; }

        [Required, StringLength(50)]
        public string AccGroup { get; set; }
        public string IsParent { get; set; }
        [StringLength(50)]
        public string ParentAccNo { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        [StringLength(250)]
        public string Description2 { get; set; }

        //Finally, when you create, the entity is in order;
        //ID (Automatically)
        //DefaultID (#Country-0001)
        //CountryName (KADİRLİ)
        //ProvinceId (Province Automatic id from Entity)
        //Description (Add)
        //Status (True,False)
  }
}