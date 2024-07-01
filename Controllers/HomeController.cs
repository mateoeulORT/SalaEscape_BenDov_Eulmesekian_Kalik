using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SalaEscape_BenDov_Eulmesekian_Kalik.Models;

namespace SalaEscape_BenDov_Eulmesekian_Kalik.Controllers;

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
}
