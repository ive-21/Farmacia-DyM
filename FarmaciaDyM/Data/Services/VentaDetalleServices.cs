using FarmaciaDyM.Data.Context;
using FarmaciaDyM.Data.Entities;
using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaDyM.Data.Services
{
    public class Result
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string message { get; internal set; }
      
    }


    public class Resulttta<T>
    {

        public bool Success { get; set; }
        public string? message { get; set; }
        public T? Data;
    }


    public class VentaDetalleServices : IVentaDetalleServices
    {
        private readonly IMyDbContext dbContext;

        public VentaDetalleServices(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Resultando> Crear(VentasDetalleRequest request)
        {
            try
            {
                var venta = VentaDetalle.crear(request);

                dbContext.VentaDetalles.Add(venta);
                await dbContext.SaveChangesAsync();
                return new Resultando() { Message = "OK", Success = true };

            }

            catch (Exception E)
            {

                return new Resultando() { Message = E.Message, Success= false };
            }




        }
        public async Task<Resultando> Eliminar(VentasDetalleRequest request)
        {
            try
            {
                var ventaDetalle = await dbContext.VentaDetalles.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (ventaDetalle == null)
                    return new Resultando () { Message= "No se Encontro El Detalle", Success = false };
                dbContext.VentaDetalles.Remove(ventaDetalle);
                await dbContext.SaveChangesAsync();
                return new Resultando() { Message = "OK", Success = true };


            }

            catch (Exception E)
            {

                return new Resultando() { Message = E.Message, Success = false };
            }

        }
        public async Task<Resultando> Modificar(VentasDetalleRequest request)
        {
            try
            {
                var ventaDetalle = await dbContext.VentaDetalles.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (ventaDetalle == null)
                    return new Resultando() { Message = "No se Encontro El Detalle de la venta", Success = false };
                if (ventaDetalle.Modificar(request))
                    await dbContext.SaveChangesAsync();
                return new Resultando() { Message = "OK", Success= true };




            }

            catch (Exception E)
            {

                return new Resultando() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result<List<VentaDetalleResponse>>> Consultar(string Filtro)
        {
            try
            {
                var Venta = await dbContext.VentaDetalles.Where(c =>

                (c.Id + "" + c.VentaId + " " + c.PrecioDeVenta)
                .ToLower()
                .Contains(Filtro.ToLower()
                )
                )
                .Select(c => c.ToResponse())
                .ToListAsync();
                return new Resultando<List<VentaDetalleResponse>>()
                {
                    Message = "OK",
                    Success = true,
                    Data = Venta
                };
            }

            catch (Exception E)
            {

                return new Resultando<List<VentaDetalleResponse>>()
                {
                    Message = E.Message,
                    Success = false,
                };

            }

        }

        private class Resultando<T> : Result<List<VentaDetalleResponse>>
        {
            public string Message { get; set; }
            public bool Success { get; set; }
            public List<VentaDetalleResponse> Data { get; set; }
        }
    }
}
