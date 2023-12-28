using Sportstore.Models;

namespace Sportstore.ViewModels;

public class ProductListVM
{
    public IEnumerable<Product> Products { get; init; } 
        = Enumerable.Empty<Product>();
    public PagingInfo PagingInfo { get; init; } = new();
}