using CRUD.Datos;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Pages.Productos
{
    public class EditarModel : PageModel
    {

		private readonly ApplicationDbContext _contexto;

		public EditarModel(ApplicationDbContext contexto)
		{
			_contexto = contexto;
		}

		[BindProperty]
		public Producto Producto { get; set; }

		public IEnumerable<Brand> Brands { get; set; }

		public IEnumerable<Category> categories { get; set; }
		[TempData]
		public string Mensaje { get; set; }
		public async Task OnGet(int id)
        {
			Producto = await _contexto.Productos.FindAsync(id);

        }

		public async Task OnGet()
		{
			Brands = await _contexto.Brands.ToListAsync();
			categories = await _contexto.Categories.ToListAsync();
		}

		public async Task<IActionResult> OnPost()
		{
			if (ModelState.IsValid)
			{
				var CursoDesdeDB = await _contexto.Productos.FindAsync(Producto.Id);

				CursoDesdeDB.NombreProducto = Producto.NombreProducto;
				CursoDesdeDB.Descripcion = Producto.Descripcion;
				CursoDesdeDB.EnStock = Producto.EnStock;
				CursoDesdeDB.Precio = Producto.Precio;

				await _contexto.SaveChangesAsync();
				Mensaje = "Producto editado correctamente";
				return RedirectToPage("Index");
			}

			return RedirectToPage();
		}
	}
}
