using CoinMarketCapService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dca_ada.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async void OnGet()
        {
            CMCService cMCService = new CMCService();
            var data = await cMCService.GetData();
        }
    }
}