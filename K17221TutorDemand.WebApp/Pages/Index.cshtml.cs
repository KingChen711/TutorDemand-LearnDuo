using K17221TutorDemand.BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace K17221TutorDemand.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IServiceFactory _service;

        public IndexModel(ILogger<IndexModel> logger, IServiceFactory service)
        {
            _logger = logger;
            _service = service;
        }

        public void OnGet()
        {

        }
    }
}
