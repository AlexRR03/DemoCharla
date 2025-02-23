using DemoCharla.Repositories;
using Microsoft.AspNetCore.Mvc;
using DemoCharla.Models;

namespace DemoCharla.Controllers
{
    public class ProductoController : Controller
    {
        private RepositoryProducto repo;

        public ProductoController(RepositoryProducto repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["EMPRESAS"]= await this.repo.GetEmpresasAsync();  
            List<Producto> productos = await this.repo.GetProductosAsync();
            return View(productos);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteByEmpresa(int idEmpresa)
        {
            await this.repo.DeleteByEmpresa(idEmpresa);
            return RedirectToAction("Index");
        }
    }
}
