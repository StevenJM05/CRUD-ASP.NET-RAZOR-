using CRUD.Datos;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Pages.Productos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public IndexModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Producto> Productos { get; set; }

        


		[TempData]
		public string Mensaje { get; set; }

		public async Task OnGet()
        {
            Productos = await _contexto.Productos.ToListAsync();
           
        }

        public async Task<IActionResult> OnPostBorrar(int id)
        {
            var producto = await _contexto.Productos.FirstAsync();
            if(producto == null)
            {
                return NotFound();
            }

            _contexto.Productos.Remove(producto);
            await _contexto.SaveChangesAsync();
            Mensaje = "Producto borrado correctamente";
            return RedirectToPage("Index");
        }
    }
}
