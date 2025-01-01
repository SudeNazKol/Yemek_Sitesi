using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using yemekSitesi.Models;

namespace yemekSitesi.Controllers;

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
    
    [Route("/anasayfa")]
    public IActionResult Anasayfa()
    {
        return View();
    }

    [Route("/tarifler")]
    public IActionResult Tarifler()
    {
        return View();
    }

    [Route("/iletisim")]
    public IActionResult Iletisim()
    {
        return View();
    }

    [Route("/TarifEkle")]
    public IActionResult tarifEkle()
    {
        return View();
    }

    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
