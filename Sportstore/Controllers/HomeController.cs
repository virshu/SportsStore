using Microsoft.AspNetCore.Mvc;
using Sportstore.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Sportstore.Controllers;

public class HomeController(StoreDbContext context) : Controller
{
    private const int PageSize = 4;

    public async Task<IActionResult> Index(int productPage = 1)
    {
        List<Product> productList = await context.Products.OrderBy(p => p.Name)
            .Skip((productPage - 1) * PageSize).Take(PageSize)
            .ToListAsync();
        return View(productList);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => 
        View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}