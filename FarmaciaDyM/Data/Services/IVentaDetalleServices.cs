using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;

namespace FarmaciaDyM.Data.Services
{
    public interface IVentaDetalleServices
    {
        Task<Result<List<VentaDetalleResponse>>> Consultar(string Filtro);
        Task<Resultando> Crear(VentasDetalleRequest request);
        Task<Resultando> Eliminar(VentasDetalleRequest request);
        Task<Resultando> Modificar(VentasDetalleRequest request);
    }
}