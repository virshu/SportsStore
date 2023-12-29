using Microsoft.AspNetCore.Mvc;
using Sportstore.Models;

namespace Sportstore.Components;

public class CartSummaryViewComponent(Cart cart) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View(cart);
    }
}