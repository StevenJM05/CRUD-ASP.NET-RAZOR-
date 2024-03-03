using CRUD.Datos;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD.Pages.Productos
{
    public class EditBrandModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public EditBrandModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Brand Brand { get; set; }

        [TempData]
        public string Mensaje { get; set; }
        public async Task OnGet(int id)
        {
            Brand = await _contexto.Brands.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var BrandFromDB = await _contexto.Brands.FindAsync(Brand.id);

                BrandFromDB.BrandName = Brand.BrandName;
                BrandFromDB.Descripcion = Brand.Descripcion;
                BrandFromDB.Pais = Brand.Pais;

                await _contexto.SaveChangesAsync();
                Mensaje = "Marca actualizada correctamente";
                return RedirectToPage("Brand");
            }

            return RedirectToPage();
        }
    }
}
