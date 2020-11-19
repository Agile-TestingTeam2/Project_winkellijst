using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Winkellijst_ASP.Models;
using Winkellijst_ASP.Services;

namespace Winkellijst_ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMailService _mailService;

        public HomeController(ILogger<HomeController> logger, IMailService mailService)
        {
            _logger = logger;
            _mailService = mailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // GET: Home/ResetPassword
        public IActionResult ResetPassword()
        {
            return View();
        }

        // POST: Home/ResetPassword
        [HttpPost]
        public async Task<IActionResult> ResetPassword(WachtwoordVergetenViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _mailService.SendPasswordResetLink(vm.Email, "Test", "https://google.com");
            }

            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
