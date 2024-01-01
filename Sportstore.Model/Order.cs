namespace Sportstore.Model;

public partial class Order
{
    [Key]
    public int OrderId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string Line { get; set; } = null!;

    [StringLength(25)]
    [Unicode(false)]
    public string City { get; set; } = null!;

    [StringLength(5)]
    [Unicode(false)]
    public string State { get; set; } = null!;

    [StringLength(25)]
    [Unicode(false)]
    public string Zip { get; set; } = null!;

    [StringLength(25)]
    [Unicode(false)]
    public string Country { get; set; } = null!;

    public bool GiftWrap { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<CartLine> CartLines { get; set; } = new List<CartLine>();
}
