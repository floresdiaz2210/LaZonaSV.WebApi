using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaZonaSV.EntidadesDeNegocio
{
    public class Categorias
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "La categoria es obligatorio")]
        public string Categoria { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
        public List<Productos> Productos { get; set; }
    }
}
