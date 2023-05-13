using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaDyM.Data.Entities
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }
        public int ClienteId { get; set; }

        [ForeignKey(nameof(ClienteId))]
        public virtual Cliente Cliente { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public virtual ICollection<VentaDetalle> Detalles { get; set; }


    }
}
