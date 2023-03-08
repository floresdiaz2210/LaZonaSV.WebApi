using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaZonaSV.EntidadesDeNegocio
{
    public class Productos
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El producto es obligatorio")]
        public string Producto { get; set; }
        [Required(ErrorMessage = "La descripción es obligatoria es obligatorio")]
        public string Detalles { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "La imagen es obligatorio")]
        public string Imagen { get; set; }

        [ForeignKey("Categoria")]
        [Required(ErrorMessage = "La categoria es obligatoria")]
        [Display(Name = "Categorias")]
        public int categoriasId { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
        public Categorias Categorias { get; set; }
    }
}
