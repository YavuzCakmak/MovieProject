using MicroGroup.Model.Entity.Authorize;
using MicroGroup.Model.Entity.Base;
using MicroGroup.Model.Entity.Movie;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroGroup.Model.Entity.MovieEvaluation
{
    [Table("movie_evaluation")]
    public class MovieEvaluationEntity : BaseEntity
    {

        [Column("personnel_id")]
        public long PersonnelId { get; set; }

        [Column("movie_id")]
        public long MovieId { get; set; }

        [Column("average_score")]
        public decimal AverageScore { get; set; }

        [Column("note")]
        public string? Note { get; set; }

        [ForeignKey("PersonnelId")]
        public virtual PersonnelEntity Personnel { get; set; }

        [ForeignKey("MovieId")]
        public virtual MovieEntity Movie { get; set; }
    }
}
