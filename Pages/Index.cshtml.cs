using LaunchDarkly.Sdk;
using LaunchDarkly.Sdk.Server;
using LaunchDarkly.Sdk.Server.Interfaces;
using ld_sample_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;

namespace ld_sample_app.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILdClient _ldClient;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILdClient ldClient, ILogger<IndexModel> logger)
        {
            _ldClient = ldClient;
            _logger = logger;
        }

        [BindProperty]
        public Donation Donation { get; set; }

        [TempData]        
        public bool FF_DONATE_BUTTON_ON_RIGHT { get; set; }

        public IActionResult OnGet()
        {
            User user = LaunchDarkly.Sdk.User.Builder(Guid.NewGuid().ToString())
                .Anonymous(true)
                .Build();
            FF_DONATE_BUTTON_ON_RIGHT = _ldClient.BoolVariation("donate-button-on-right", user, false);
            //_logger.LogInformation("Feature flag is {flag-value}", FF_DONATE_BUTTON_ON_RIGHT);

            return Page();
        }

        public IActionResult OnPost()
        {            
            // Submit donation and log experiment
            _logger.LogInformation("Donated {donation-ammount} when feature flag is {flag-value}", Donation.Amount, FF_DONATE_BUTTON_ON_RIGHT);

            return RedirectToPage("./Index");
        }
    }
}
