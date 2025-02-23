using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoCharla.Models
{
    [Table("PRODUCTO")]
    public class Producto
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("NOMBRE")]
        public string Nombre { get; set; }
        [Column("CANTIDAD")]
        public int Cantidad { get; set; }
        [Column("EMPRESAID")]
        public int  EmpresaId { get; set; }

        public Empresa Empresa { get; set; }
    }
}
