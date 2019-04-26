using BiFi.Project.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiFi.Project.Model.Entities
{
    public class Uom: BaseStatusEntity
    {
        [Index("IX_DefaultId", IsUnique = true)]

        public override string DefaultCode { get; set; }
        [Required, StringLength(50)]

        public string UomName { get; set; }
        [StringLength(250)]

        public string Description { get; set; }
    }
}
