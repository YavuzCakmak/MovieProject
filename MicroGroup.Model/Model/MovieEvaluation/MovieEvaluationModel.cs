using MicroGroup.Model.Entity.Authorize;
using MicroGroup.Model.Entity.Movie;
using MicroGroup.Model.Model.Authorize;
using MicroGroup.Model.Model.Base;
using MicroGroup.Model.Model.Movie;

namespace MicroGroup.Model.Model.MovieEvaluation
{
    public class MovieEvaluationModel : BaseModel
    {
        public long PersonnelId { get; set; }
        public long MovieId { get; set; }
        public decimal AverageScore { get; set; }
        public string? Note { get; set; }
        public PersonnelModel? Personnel { get; set; }
        public MovieModel? Movie { get; set; }
    }
}
