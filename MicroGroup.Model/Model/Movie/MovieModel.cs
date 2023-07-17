using MicroGroup.Model.Model.Base;

namespace MicroGroup.Model.Model.Movie
{
    public class MovieModel : BaseModel
    {
        public string Name { get; set; }

        public decimal AverageScore { get; set; }
    }
}
