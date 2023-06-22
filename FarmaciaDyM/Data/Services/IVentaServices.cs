using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;

namespace FarmaciaDyM.Data.Services
{
    public interface IVentaServices
    {
        Task<Result<List<VentaResponse>>> Consultar(string Filtro);
        Task<Result> Crear(VentasRequest request);
        Task<Result> Eliminar(VentasRequest request);
        Task<Result> MOdificar(VentasRequest request);
    }
}