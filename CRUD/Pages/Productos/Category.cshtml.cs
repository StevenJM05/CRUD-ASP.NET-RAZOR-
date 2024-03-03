using CRUD.Datos;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Pages.Productos
{
    public class CategoryModel : PageModel
    {

		private readonly ApplicationDbContext _contexto;

		public CategoryModel(ApplicationDbContext contexto)
		{
			_contexto = contexto;
		}

		public IEnumerable<Category> Categories { get; set; }




		[TempData]
		public string Mensaje { get; set; }
		public async Task OnGet()
        {
			Categories = await _contexto.Categories.ToListAsync();
        }

		public async Task<IActionResult> OnPostBorrar(int id)
		{
			var categoria = await _contexto.Categories.FirstAsync();
			if (categoria == null)
			{
				return NotFound();
			}

			_contexto.Categories.Remove(categoria);
			await _contexto.SaveChangesAsync();
			Mensaje = "Categoria borrada correctamente";
			return RedirectToPage("Category");
		}
	}
}
