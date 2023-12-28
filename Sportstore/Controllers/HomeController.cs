using Microsoft.AspNetCore.Mvc;
using Sportstore.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Sportstore.ViewModels;

namespace Sportstore.Controllers;

public class HomeController(StoreDbContext context) : Controller
{
    private const int PageSize = 4;


    public async Task<IActionResult> Index(string?  category, int productPage = 1)
    {
        List<Product> productList = await context.Products
            .Where(p => category == null || p.Category == category)
            .OrderBy(p => p.Name)
            .Skip((productPage - 1) * PageSize).Take(PageSize)
            .ToListAsync();

        return View(new ProductListVM
        {
            Products = productList,
            PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = context.Products.Count(GetCount)
            },
            CurrentCategory = category
        });
        // https://stackoverflow.com/questions/6308328/type-of-conditional-expression-cannot-be-determined-func
        bool GetCountByCategoryFunc(Product p) => p.Category == category;
        bool GetCountFunc() => true;
        bool GetCount(Product p) => string.IsNullOrEmpty(category) ? GetCountFunc() : GetCountByCategoryFunc(p);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => 
        View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}