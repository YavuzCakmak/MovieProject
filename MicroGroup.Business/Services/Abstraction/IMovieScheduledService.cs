using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroGroup.Business.Services.Abstraction
{
    public interface IMovieScheduledService
    {
        Task GetMovieAndSave();
    }
}
