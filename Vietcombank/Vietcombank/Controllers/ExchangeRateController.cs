using System;
using Microsoft.AspNetCore.Mvc;
using Vietcombank.Services;
using Vietcombank.ViewModels;

namespace Vietcombank.Controllers
{
    using static WebConstants;
    public class ExchangeRateController : Controller
    {
        private readonly IExchangeRateService exchangeRateService;

        public ExchangeRateController(IExchangeRateService exchangeRateService)
        {
            this.exchangeRateService = exchangeRateService;
        }

        public IActionResult Index(int page= DefaultPage)
        {
            var exrates = this.exchangeRateService.All(page, PageSize);

            return View(new ExrateViewModel
            {
                Exrates = exrates,

                CurrentPage = page,

                TotalPages = (int)Math.Ceiling(this.exchangeRateService.Total() / (double)PageSize)
            });

            
        }
    }
}