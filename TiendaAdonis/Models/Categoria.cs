using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaAdonis.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        public bool Estado { get; set; }
    }
}