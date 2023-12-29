using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sportstore.Models;

namespace Sportstore.Pages
{
    public class CartModel(StoreDbContext context, Cart cart) : PageModel
    {
        public Cart Cart { get; set; } = cart;

        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string? returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(long productId, string returnUrl) {
            Product? product = context.Products.FirstOrDefault(p => p.ProductID == productId);

            if (product != null) {
                Cart.AddItem(product, 1);
            }

            return RedirectToPage(new { returnUrl });
        }

        public IActionResult OnPostRemove(long productId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(c => c.Product.ProductID == productId).Product);
            return RedirectToPage(new { returnUrl });
        }
    }
}
