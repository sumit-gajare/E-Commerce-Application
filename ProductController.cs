public class ProductController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    public ActionResult Index()
    {
        var products = db.Products.ToList();
        return View(products);
    }
}