using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;

namespace FarmaciaDyM.Data.Services
{
    public interface IVentaServices
    {
        Task<Result<List<VentaResponse>>> Consultar(string Filtro);
        Task<Resultados> Crear(VentasRequest request);
        Task<Resultados> Eliminar(VentasRequest request);
        Task<Resultados> MOdificar(VentasRequest request);
    }
}