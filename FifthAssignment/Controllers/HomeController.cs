using FifthAssignment.Core.Application.Interfaces.Contracts;
using FifthAssignment.Models;
using FifthAssignment.Presentation.WebApp.Enums;
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
			if (TempData[MessageType.MessageError.ToString()] != null)
			{
				ViewBag[MessageType.MessageError.ToString()] = TempData[MessageType.MessageError.ToString()];
			}
			if (TempData[MessageType.MessageSuccess.ToString()] != null)
			{
				ViewBag[MessageType.MessageSuccess.ToString()] = TempData[MessageType.MessageSuccess.ToString()];
			}
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
