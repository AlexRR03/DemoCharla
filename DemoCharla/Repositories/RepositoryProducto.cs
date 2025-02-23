using DemoCharla.Data;
using DemoCharla.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoCharla.Repositories
{
    public class RepositoryProducto
    {
        private ProductoContext productoContext;
        public RepositoryProducto(ProductoContext productoContext)
        {
            this.productoContext = productoContext;
        }   

        public async Task<List<Producto>> GetProductosAsync()
        {
            var consulta = from datos in this.productoContext.Productos
                           .Include(p=>p.Empresa) select datos;
            return await consulta.ToListAsync();
        }
        public async Task<List<Empresa>> GetEmpresasAsync()
        {
            return await this.productoContext.Empresas.ToListAsync();
        }
       
        public async Task DeleteByEmpresa(int idEmpresa)
        {
            var empresa = await this.productoContext.Empresas.FindAsync(idEmpresa);
            int registrosEliminados = await productoContext.Productos
           .Where(p => p.EmpresaId == idEmpresa)
           .ExecuteDeleteAsync();
           
        }
    }
}
