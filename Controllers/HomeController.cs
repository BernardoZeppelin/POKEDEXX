using Microsoft.AspNetCore.Mvc;
using POKEDEXX.Models;
using POKEDEXX.Services;
using System.Diagnostics;
using System.Threading.Tasks;

namespace POKEDEXX.Controllers;

public class HomeController : Controller
{
    private readonly PokeApiService _pokeApiService;

    public HomeController(PokeApiService pokeApiService)
    {
        _pokeApiService = pokeApiService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
 
    public async Task<IActionResult> Index(string searchTerm) // !!
    {
  
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            ViewData["ErrorMessage"] = "Por favor, digite um nome ou número de Pokémon.";
            return View();
        }

        
        var pokemon = await _pokeApiService.GetPokemonAsync(searchTerm.ToLower());

        if (pokemon == null)
        {

            ViewData["ErrorMessage"] = $"Pokémon '{searchTerm}' não foi encontrado. Tente outro.";
        }

        return View(pokemon);
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
