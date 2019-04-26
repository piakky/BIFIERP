namespace BiFi.Project.Model.Entities.Base
{
    public class BaseStatusEntity:BaseEntity
    {
        public bool Status { get; set; } = true;//This entity will be used in records we will know as Active Passive
        //In this case, Id, Default Id and Status fields will come automatically.
    }
}
