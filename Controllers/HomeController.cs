using DispatchSys.Applications;
using DispatchSys.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DispatchSys.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Searcher _searcher;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _searcher = new();
    }

    public IActionResult Index(string name)
    {
        _searcher.Submit(name);
        _logger.LogInformation("User input = {Name}", name);
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        _logger.LogError("RequestId = {message}", Activity.Current?.Id ?? HttpContext.TraceIdentifier);
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}