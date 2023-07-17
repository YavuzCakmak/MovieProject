using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MicroGroup.Model.Entity.Base
{
    public class BaseEntity
    {
        [Column("id")]
        [Key]
        public long Id { get; set; }

        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
