using CRUD.Datos;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD.Pages.Productos
{
    public class CreateCategoryModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public CreateCategoryModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]

        public Category Category { get; set; }

		[TempData]

		public string Mensaje {  get; set; }
        public void OnGet()
        {
        }

		public async Task<IActionResult> OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			
			_contexto.Add(Category);
			await _contexto.SaveChangesAsync();
			Mensaje = "Categoria creada correctamente";
			return RedirectToPage("Category");
		}
	}
}
