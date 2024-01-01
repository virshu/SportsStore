namespace Sportstore.Model;

public partial class CartLine
{
    [Key]
    public int CartLineId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public int OrderId { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("CartLines")]
    public virtual Order Order { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("CartLines")]
    public virtual Product Product { get; set; } = null!;
}
