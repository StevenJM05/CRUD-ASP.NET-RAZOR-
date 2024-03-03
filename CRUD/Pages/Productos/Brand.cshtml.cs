using CRUD.Datos;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Pages.Productos
{
    public class BrandModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public BrandModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        
        public IEnumerable<Brand> Brands { get; set; }

        [TempData]

        public string Mensaje { get; set; }

        public async Task OnGet()
        {
            Brands = await _contexto.Brands.ToListAsync();
        }

        public async Task<IActionResult> OnPostBorrar(int id)
        {
			var brand = await _contexto.Brands.FirstAsync();

			if (brand == null)
            {
                return NotFound();
            }

            _contexto.Brands.Remove(brand);
            await _contexto.SaveChangesAsync();
            Mensaje = "Marca borrada correctamente";
            return RedirectToPage("Brand");
        }
    }
}
