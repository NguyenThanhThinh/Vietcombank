using System.Collections.Generic;
using Vietcombank.Models;

namespace Vietcombank.Services
{
    using static ServiceConstants;
    public interface IExchangeRateService
    {
        IEnumerable<Exrate> All(int page = DefaultPage, int pageSize = DefaultPageSize);

        int Total();
    }
}
