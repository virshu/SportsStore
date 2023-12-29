namespace Sportstore.Models;

public class Cart
{
    public List<CartLine> Lines { get; set; } = [];

    public virtual void AddItem(Product product, int quantity) {
        CartLine? line = Lines.Find(p => p.Product.ProductID == product.ProductID);
                                
        if (line == null) {
            Lines.Add(new CartLine {
                Product = product,
                Quantity = quantity
            });
        } else {
            line.Quantity += quantity;
        }
    }

    public virtual void RemoveLine(Product product) => Lines.RemoveAll(l => l.Product.ProductID == product.ProductID);
    public decimal ComputeTotalValue() => Lines.Sum(e => e.Product.Price * e.Quantity);
    public virtual void Clear() => Lines.Clear();
}