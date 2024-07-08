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
    public IActionResult Tutorial()
    {
        return View();
    }   

    public IActionResult Habitacion(int sala, string clave)
    {
        if (sala != Escape.GetEstadoJuego())
        {
            return View("Habitacion" + Escape.GetEstadoJuego());
        }

        if (Escape.ResolverSala(sala, clave) && Escape.GetEstadoJuego() == 5)
        {
            return View("Victoria");
        } 
        else if(Escape.ResolverSala(sala, clave))
        {
            return View("Habitacion" + Escape.GetEstadoJuego());
        }
        else{
            ViewBag.Error = "Datos mal ingresados";
            return View("Habitacion" + Escape.GetEstadoJuego());
        }


    }
    public IActionResult Comenzar()
    {
        ViewBag.EstadoJuego = Escape.GetEstadoJuego();
        return View("Habitacion" + ViewBag.EstadoJuego);
    }
    


}
