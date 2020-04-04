using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignalRCore.Web.Models;
using SignalRCore.Web.Repositories;

namespace SignalRCore.Web.Controllers
{
    public class ReleaseController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReleaseRepository _releaseRepository;

        public ReleaseController(ILogger<HomeController> logger, IReleaseRepository releaseRepository)
        {
            _logger = logger;
            _releaseRepository = releaseRepository;
        }

        public IActionResult Index()
        {
            return View(_releaseRepository.GetMessages());
        }
    }
}