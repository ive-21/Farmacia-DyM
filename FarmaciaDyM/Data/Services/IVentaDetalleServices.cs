using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;

namespace FarmaciaDyM.Data.Services
{
    public interface IVentaDetalleServices
    {
        Task<Result<List<VentaDetalleResponse>>> Consultar(string Filtro);
        Task<Resultados> Crear(VentasDetalleRequest request);
        Task<Resultados> Eliminar(VentasDetalleRequest request);
        Task<Resultados> Modificar(VentasDetalleRequest request);
    }
}