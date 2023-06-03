using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaDyM.Data.Entities
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public int Existencia { get; set; }
        public DateTime FechaDeCaducidad { get; set; }
        public int ProveedorId { get; set; }

        [ForeignKey(nameof(ProveedorId))]
        public virtual Proveedor Proveedor { get; set; }

        public static Producto crear(ProductosRequest productos)
       => new Producto()
       {
           Codigo = productos.Codigo,
           Nombre = productos.Nombre,
           Costo = productos.Costo,
           Precio = productos.Precio,
           Existencia = productos.Existencia,
           FechaDeCaducidad = productos.FechaDeCaducidad,
           ProveedorId = productos.ProveedorId,
       };
        public bool Modificar(ProductosRequest productos)
        {
            var cambio = false;
            if (Codigo != productos.Codigo)
            {
                Codigo = productos.Codigo;
                cambio = true;
            }
            if (Nombre != productos.Nombre)
            {
                Nombre = productos.Nombre;
                cambio = true;
            }
            if (Costo != productos.Costo)
            {
                Costo = productos.Costo;
                cambio = true;
            }

            if (Precio != productos.Precio)
            {
                Precio = productos.Precio;
                cambio = true;
            }
            if (Existencia != productos.Existencia)
            {
                Existencia = productos.Existencia;
                cambio = true;
            }
            if (FechaDeCaducidad != productos.FechaDeCaducidad)
            {
                FechaDeCaducidad = productos.FechaDeCaducidad;
                cambio = true;
            }
            if (ProveedorId != productos.ProveedorId)
            {
                ProveedorId = productos.ProveedorId;
                cambio = true;
            }

            return cambio;


        }


        public ClienteResponse ToResponse()
          => new ClienteResponse()
          {
             
          };

    }
}
