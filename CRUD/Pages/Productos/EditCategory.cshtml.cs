using CRUD.Datos;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;

namespace CRUD.Pages.Productos
{
	public class EditCategoryModel : PageModel
	{
		private readonly ApplicationDbContext _contexto;

		public EditCategoryModel(ApplicationDbContext contexto)
		{
			_contexto = contexto;
		}

		[BindProperty]
		public Category Category { get; set; }
		[TempData]
		public string Mensaje { get; set; }
		public async Task OnGet(int id)
		{
			Category = await _contexto.Categories.FindAsync(id);
		}

		public async Task<IActionResult> OnPost()
		{
			if (ModelState.IsValid)
			{
				var CategoryFromDB = await _contexto.Categories.FindAsync(Category.Id);

				CategoryFromDB.CategoryName = Category.CategoryName;
				CategoryFromDB.Descripcion = Category.Descripcion;

				await _contexto.SaveChangesAsync();
				Mensaje = "Categoria editada correctamente";
				return RedirectToPage("Category");
			}

			return RedirectToPage();
		}
	}
}
