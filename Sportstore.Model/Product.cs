namespace Sportstore.Model;

public partial class Product
{
    [Key]
    public int ProductId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(250)]
    public string? Description { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string Category { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ICollection<CartLine> CartLines { get; set; } = new List<CartLine>();
}
