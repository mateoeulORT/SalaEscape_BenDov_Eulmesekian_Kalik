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

        bool respuestaCorrecta = Escape.ResolverSala(sala, clave);
    
        if (respuestaCorrecta)
        {
            if (Escape.GetEstadoJuego() > 5) 
            {
                return View("Victoria"); 
            }
            else
            {
                return View("Habitacion" + Escape.GetEstadoJuego());
            }
        }
        else
        {

            ViewBag.Error = "La respuesta es incorrecta. Intenta nuevamente.";
            return View("Habitacion" + sala); 
        }

        }
    public IActionResult Comenzar()
    {
        ViewBag.EstadoJuego = Escape.GetEstadoJuego();
        return View("Habitacion" + ViewBag.EstadoJuego);
    }
    
    public IActionResult MostrarCarta()
    {
        ViewBag.On = true;
        ViewBag.Parrafo1 = "<p>Compañero de celda,</p>";
        ViewBag.Parrafo2 = "<p>La luz de la luna se cuela por los barrotes, y con ella viene un mensaje oculto. En el eco de los pasos del guardia, cada golpe de su bastón contra el suelo es una clave. Un golpe fuerte es un 1, un golpe suave es un 0.</p>";
        ViewBag.Parrafo3 = "<p>Descifra la secuencia de los golpes y conviértela a ese formato antiguo que simboliza el número 16. Solo así podrás abrir la puerta de nuestra libertad.</p>";
        ViewBag.Parrafo4 = "<p>Con esperanza, Tu confidente </p>";
        return View("Habitacion1");
    }

    public IActionResult InfoGrifos(string grifo)
    {
        ViewBag.Activado = true;

        if (grifo == "grifo1")
        {
            ViewBag.Letra = "X";
            ViewBag.Posicion = "2";
        }
        else if (grifo == "grifo2")
        {
            ViewBag.Letra = "T";
            ViewBag.Posicion = "4";
        }
        else if (grifo == "grifo3")
        {
            ViewBag.Letra = "E";
            ViewBag.Posicion = "1";
        }
        else if (grifo == "grifo4")
        {
            ViewBag.Letra = "I";
            ViewBag.Posicion = "3";
        }

        return View("Habitacion2");
    }

    public IActionResult CerrarVentana()
    {
        return View("Habitacion2");
    }
}
