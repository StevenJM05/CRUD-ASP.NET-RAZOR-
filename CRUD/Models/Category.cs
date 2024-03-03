using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre del producto")]
        public string CategoryName { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}
