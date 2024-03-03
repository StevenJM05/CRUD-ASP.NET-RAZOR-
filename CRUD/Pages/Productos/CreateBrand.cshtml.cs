using CRUD.Datos;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD.Pages.Productos
{
    public class CreateBrandModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public CreateBrandModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]

        public Brand brand { get; set; }

		[TempData]

		public string Mensaje { get; set; }

		public void OnGet()
        {
        }

		public async Task<IActionResult> OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}


			_contexto.Add(brand);
			await _contexto.SaveChangesAsync();
			Mensaje = "Marca creada correctamente";
			return RedirectToPage("Brand");
		}
	}
}
