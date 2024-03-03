using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Brand
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public  string  BrandName { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "País")]
        public  string Pais { get; set; }

    }
}
