using Microsoft.AspNetCore.Mvc;

namespace Testing.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repo;
        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var products = repo.GetAllProducts();
            return View(products);
        }
        public IActionResult ViewProduct(int id)
        {
            var product = repo.GetProduct(id);
            return View(product);
        }
        public IActionResult UpdateProduct(int id)
        {
            Product prod = repo.GetProduct(id);
            if(prod == null)
                {
                    return View("ProductNotFound");
                }
            return View(prod);
        }
        public IActionResult UpdateProductToDatabase(Product product)
        {
            repo.UpdateProduct(product);
            return RedirectToAction("ViewProduct", new {id = product.ProductID});
        }
        public IActionResult InsertProduct(Product productToInstert)
        {
            var prod = repo.AssignCategory();
            return View(prod);
        }
        public IActionResult InsertProductToDatabase(Product productToInsert)
        {
            repo.InsertProduct(productToInsert);
            return RedirectToAction("index");
        }
        public IActionResult DeleteProduct(Product product)
        {
            repo.DeleteProduct(product);

            return RedirectToAction("Index");
        }

    }
}
