using MicroGroup.Model.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroGroup.Model.Entity.Authorize
{
    [Table("role")]
    public class RoleEntity : BaseEntity
    {
        
        [Column("name")]
        public string Name { get; set; }
    }
}
