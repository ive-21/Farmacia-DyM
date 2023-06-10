using FarmaciaDyM.Data.Context;
using FarmaciaDyM.Data.Entities;
using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaDyM.Data.Services
{
    public class Resultando
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }


    public class Resulttta<T>
    {

        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data;
    }


    public class VentaDetalleServices : IVentaDetalleServices
    {
        private readonly IMyDbContext dbContext;

        public VentaDetalleServices(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Resultados> Crear(VentasDetalleRequest request)
        {
            try
            {
                var venta = VentaDetalle.crear(request);

                dbContext.VentaDetalles.Add(venta);
                await dbContext.SaveChangesAsync();
                return new Resultados() { Message = "OK", Succes = true };

            }

            catch (Exception E)
            {

                return new Resultados() { Message = E.Message, Succes = false };
            }




        }
        public async Task<Resultados> Eliminar(VentasDetalleRequest request)
        {
            try
            {
                var ventaDetalle = await dbContext.VentaDetalles.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (ventaDetalle == null)
                    return new Resultados() { Message = "No se Encontro El Detalle", Succes = false };
                dbContext.VentaDetalles.Remove(ventaDetalle);
                await dbContext.SaveChangesAsync();
                return new Resultados() { Message = "OK", Succes = true };


            }

            catch (Exception E)
            {

                return new Resultados() { Message = E.Message, Succes = false };
            }

        }
        public async Task<Resultados> Modificar(VentasDetalleRequest request)
        {
            try
            {
                var ventaDetalle = await dbContext.VentaDetalles.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (ventaDetalle == null)
                    return new Resultados() { Message = "No se Encontro El Detalle de la venta", Succes = false };
                if (ventaDetalle.Modificar(request))
                    await dbContext.SaveChangesAsync();
                return new Resultados() { Message = "OK", Succes = true };




            }

            catch (Exception E)
            {

                return new Resultados() { Message = E.Message, Succes = false };
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
                return new Result<List<VentaDetalleResponse>>()
                {
                    Message = "OK",
                    Success = true,
                    Data = Venta
                };
            }

            catch (Exception E)
            {

                return new Result<List<VentaDetalleResponse>>()
                {
                    Message = E.Message,
                    Success = false,
                };

            }

        }

    }
}
