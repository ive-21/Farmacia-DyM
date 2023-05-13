namespace FarmaciaDyM.Data.Entities
{
    public class Cliente
    {

        public DateTime Fecha { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public ICollection<Venta> Ventas { get; set; }


    }
}
