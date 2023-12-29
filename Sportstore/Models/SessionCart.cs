using System.Text.Json.Serialization;
using Sportstore.Infrastructure;

namespace Sportstore.Models;

public class SessionCart : Cart
{
    [JsonIgnore]
    public ISession? Session { get; set; }

    public static Cart GetCart(IServiceProvider services) {
        ISession? session = services.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session;
        SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
        cart.Session = session;
        return cart;
    }

    public override void AddItem(Product product, int quantity)
    {
        base.AddItem(product, quantity);
        Session?.SetJson("SportStoreCart", this);
    }

    public override void RemoveLine(Product product)
    {
        base.RemoveLine(product);
        Session?.SetJson("SportStoreCart", this);
    }

    public override void Clear()
    {
        base.Clear();
        Session?.Remove("SportStoreCart");
    }

}