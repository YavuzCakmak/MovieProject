using MicroGroup.Core.Business.Abstraction;
using MicroGroup.Data.Context;
using MicroGroup.Data.Repository.Abstraction;
using MicroGroup.Model.Dto;
using MicroGroup.Model.Entity.Movie;
using MicroGroup.Model.Model.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroGroup.Business.Services.Abstraction
{
    public interface IMovieService : IBusinessService<MovieEntity, MovieModel, IMovieRepository, MicroGroupDbContext>
    {
        public void AdviceMovie(AdviceMovieDto adviceMovieDto);
    }
}
