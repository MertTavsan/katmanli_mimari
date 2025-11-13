using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using katmanli_mimari.Web.Models;
using katmanli_mimari.Services;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
//using katmanli_mimari.Data;

namespace katmanli_mimari.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
  private readonly Service _service;

    public HomeController(ILogger<HomeController> logger,Service service)
    {
        _logger = logger;
        _service = service;

    }

    public async Task<IActionResult> Index(int id)
    {
        
        string name=_service.GetUserName("Mert","Tavşan");
        ViewData["m"]=name;
       // var users=await _service.GetAllUsersAsync();
        //if (id>0) users=await _service.GetUserByIDAsync(id); 

        if(id==0)
        {
            var users= await _service.GetAllUsersAsync();
            return View(users);
        }
        else
        {
             var users= await _service.GetUserByIDAsync(id);
            return View(users);
        }
        
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
