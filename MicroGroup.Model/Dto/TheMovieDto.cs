using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroGroup.Model.Dto
{
    public class TheMovieDto
    {
        public List<Content> Results { get; set; }
    }

    public class Content
    {
        public string original_title { get; set; }
        public decimal vote_average { get; set; }
    }
}
