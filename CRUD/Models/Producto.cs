using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
	public class Producto
	{
		[Key]	
        public int Id { get; set; }
		[Required]
		[Display(Name = "Nombre del producto")]
		public string NombreProducto { get; set; }
		[Display(Name = "Descripción")]
		public string Descripcion { get; set; }
		[Display(Name = "Cantidad en Stock")]
		public int EnStock { get; set; }
		public double Precio { get; set; }
		[Display(Name = "Fecha de creación")]
		public  DateTime FechaCreacion { get; set; }

		[Display(Name = "ID Marca")]
        public int BrandId { get; set; }

		[Display(Name = "ID Categoria")]
		public int CategoryId { get; set; }

		public Brand Brand { get; set; }
		public Category Category { get; set; }


    }
}
