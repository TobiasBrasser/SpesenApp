using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SpesenApp.Models;

namespace SpesenApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

/*************  ✨ Windsurf Command ⭐  *************/
/// <summary>
/// Handles the HTTP request for the Privacy page.
/// </summary>
/// <returns>A ViewResult that renders the Privacy view.</returns>

/*******  22947ab1-81f8-4605-9d52-a5b62d0e5a7a  *******/
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
