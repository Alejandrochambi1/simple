using System.ComponentModel.DataAnnotations;

namespace simple.Entidades
{
    public class Articulo
    {
        [Key]
        public int ArticuloId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public  string codigo { get; set; }
    }
}
