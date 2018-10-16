using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vietcombank.ViewModels
{
    using Vietcombank.Models;

    public class ExrateViewModel : Pager
    {
        public IEnumerable<Exrate> Exrates { get; set; }
    }
}
