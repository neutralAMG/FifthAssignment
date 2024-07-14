using FifthAssignment.Core.Application.Interfaces.Contracts;
using FifthAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FifthAssignment.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IHomeService _homeService;

		public HomeController(ILogger<HomeController> logger, IHomeService homeService)
		{
			_logger = logger;
			_homeService = homeService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
