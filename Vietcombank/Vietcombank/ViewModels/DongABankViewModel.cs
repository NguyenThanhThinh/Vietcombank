using System.Collections.Generic;
using Vietcombank.Models;

namespace Vietcombank.ViewModels
{
    public class DongABankViewModel:Pager
    {
        public IEnumerable<Item> Items { get; set; }
    }
}
