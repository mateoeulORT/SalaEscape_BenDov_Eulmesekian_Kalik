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

    public IActionResult Creditos()
    {
        return View();
    }

    public IActionResult Habitacion(int sala, string clave)
    {
        ViewBag.ObjetoEncontrado = false;
        ViewBag.RompioVidrio = false;
        ViewBag.Escalar = false;

        if (sala != Escape.GetEstadoJuego())
        {
            return View("Habitacion" + Escape.GetEstadoJuego());
        }

        bool respuestaCorrecta = Escape.ResolverSala(sala, clave);
    
        if (respuestaCorrecta)
        {
            if (Escape.GetEstadoJuego() > 4) 
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
        }
        else if (grifo == "grifo2")
        {
            ViewBag.Letra = "T";
        }
        else if (grifo == "grifo3")
        {
            ViewBag.Letra = "E";
        }
        else if (grifo == "grifo4")
        {
            ViewBag.Letra = "I";
        }

        return View("Habitacion2");
    }

    public IActionResult CerrarVentana()
    {
        ViewBag.EstadoJuego = Escape.GetEstadoJuego();
        return View("Habitacion" + ViewBag.EstadoJuego);
    }

    public IActionResult ObjetoEncontrado()
    {
        ViewBag.ObjetoEncontrado = true; 
        ViewBag.EstadoJuego = Escape.GetEstadoJuego(); 
        return View("Habitacion" + ViewBag.EstadoJuego);
    }


    public IActionResult RomperVidrio()
    {
        ViewBag.RompioVidrio = true;
        return View("Habitacion3");
    }

    public IActionResult Escalar()
    {
        ViewBag.Escalar = true;
        return View("Habitacion4");
    }
}
