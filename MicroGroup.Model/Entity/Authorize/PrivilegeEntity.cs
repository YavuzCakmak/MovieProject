using MicroGroup.Model.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroGroup.Model.Entity.Authorize
{
    [Table("privilege")]
    public class PrivilegeEntity : BaseEntity
    {
        [Column("name")]
        
        public string Name { get; set; }
    }
}
