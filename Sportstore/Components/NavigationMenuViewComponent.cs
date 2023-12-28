using Microsoft.AspNetCore.Mvc;
using Sportstore.Models;

namespace Sportstore.Components;

public class NavigationMenuViewComponent(StoreDbContext context) : ViewComponent
{
    public  IViewComponentResult Invoke()
    {
        List<string> categories =
        [
            .. context.Products.Select(p => p.Category).Distinct().OrderBy(p => p)
        ];
        ViewBag.SelectedCategory = RouteData.Values["category"] ?? "";
        return View(categories);
    }
}
