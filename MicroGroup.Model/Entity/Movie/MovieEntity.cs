using MicroGroup.Model.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroGroup.Model.Entity.Movie
{
    [Table("movie")]
    public class MovieEntity : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("average_score")]
        public decimal AverageScore { get; set; }

    }
}
