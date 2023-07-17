using MicroGroup.Core.Utilities;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroGroup.Core.Sieve
{
    public class BaseApplicationSieveProcessor<TFilterModel, TFilterTerm, TSortTerm> : SieveProcessor<DataFilterModel, FilterTerm, SortTerm>
    {
        public BaseApplicationSieveProcessor(IOptions<SieveOptions> options) : base(options)
        {
        }
    }
}
