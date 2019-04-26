using BiFi.Project.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiFi.Project.Model.Entities
{
    public class Province: BaseStatusEntity// To add Status Column
    {
        [Index("IX_DefaultId", IsUnique = true)] //It provides an indexing feature in an specific column in the database.
        public override string DefaultCode { get; set; } //we define the DefaultCode component we will use in all tables.
        [Required, StringLength(50)] //we do the StringLength property of the ProvinceName column 50, which we will define below. Maximum 50 characters
        public string ProvinceName { get; set; } //ProvinceName Column Add
        [StringLength(250)]// Description column unun StringLength property of the ProvinceName column 250, which we will define below. Maximum 250 characters
        public string Description { get; set; } //Description Column Add

        //Finally, when you create, the entity is in order;
        //ID (Automatically)
        //DefaultCode (#Province-0001)
        //ProvinceName (Osmaniye)
        //Description (Province Add)
        //Status (True,False)
    }
}