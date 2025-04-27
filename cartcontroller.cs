public class CartController : Controller
{
    private static List<CartItem> cart = new List<CartItem>();

    public ActionResult Index() => View(cart);

    public ActionResult AddToCart(int id)
    {
        var product = new ApplicationDbContext().Products.Find(id);
        var item = cart.FirstOrDefault(c => c.Product.Id == id);
        if (item != null)
            item.Quantity++;
        else
            cart.Add(new CartItem { Product = product, Quantity = 1 });

        return RedirectToAction("Index");
    }

    public ActionResult RemoveFromCart(int id)
    {
        var item = cart.FirstOrDefault(c => c.Product.Id == id);
        if (item != null) cart.Remove(item);
        return RedirectToAction("Index");
    }
}