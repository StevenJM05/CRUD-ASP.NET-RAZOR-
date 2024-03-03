using CRUD.Datos;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Pages.Productos
{
    public class CrearModel : PageModel
    {
		private readonly ApplicationDbContext _contexto;

		public CrearModel(ApplicationDbContext contexto)
		{
			_contexto = contexto;
		}

		[BindProperty]
		public Producto Producto { get; set; }
		public IEnumerable<Brand> brands { get; set; }
		public IEnumerable<Category> Categories { get; set; }

		[TempData]
		public string Mensaje { get; set; }

		public async Task OnGet()
        {
			brands = await _contexto.Brands.ToListAsync();
			Categories = await _contexto.Categories.ToListAsync();
        }

		

		public async Task<IActionResult> OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			Producto.FechaCreacion = DateTime.Now;
			_contexto.Add(Producto);
			await _contexto.SaveChangesAsync();
			Mensaje = "Producto creado correctamente";
			return RedirectToPage("Index");
		}
    }
}
