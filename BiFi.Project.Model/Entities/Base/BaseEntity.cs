using BiFi.Project.Model.Entities.Base.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiFi.Project.Model.Entities.Base
{
    public class BaseEntity:IBaseEntity
    {
        //The entity to be used for data entries in standard forms. Order sorting, Key primary key, DatabaseGeneratedOption = lack of increasing order,
        //Required compulsory,StringLength maximum length

        [Column(Order = 0), Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [Column(Order = 1), Required, StringLength(20)]
        public virtual string DefaultCode { get; set; }
    }
}