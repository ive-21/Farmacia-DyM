using FarmaciaDyM.Data.Context;
using FarmaciaDyM.Data.Entities;
using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaDyM.Data.Services
{





    public class VentaServices : IVentaServices
    {
        private readonly IMyDbContext dbContext;

        public VentaServices(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
            {

            }

        }

        public async Task<Resultados> Crear(VentasRequest request)
        {
            try
            {
                var venta = Venta.crear(request);

                dbContext.Ventas.Add(venta);
                await dbContext.SaveChangesAsync();
                return new Resultados() { Message = "OK", Succes = true };

            }

            catch (Exception E)
            {

                return new Resultados() { Message = E.Message, Succes = false };
            }

        }

        public async Task<Resultados> MOdificar(VentasRequest request)
        {
            try
            {
                var venta = await dbContext.Ventas.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (venta == null)
                    return new Resultados() { Message = "No se Encontro La Venta", Succes = false };
                if (venta.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Resultados() { Message = "OK", Succes = true };




            }

            catch (Exception E)
            {

                return new Resultados() { Message = E.Message, Succes = false };
            }
        }

        public async Task<Resultados> Eliminar(VentasRequest request)
        {
            try
            {
                var venta = await dbContext.Ventas.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (venta == null)
                    return new Resultados() { Message = "No se Encontro El Producto", Succes = false };
                dbContext.Ventas.Remove(venta);
                await dbContext.SaveChangesAsync();
                return new Resultados() { Message = "OK", Succes = true };


            }

            catch (Exception E)
            {

                return new Resultados() { Message = E.Message, Succes = false };
            }

        }
        public async Task<Result<List<VentaResponse>>> Consultar(string Filtro)
        {
            try
            {
                var venta = await dbContext.Ventas.Where(c =>

                (c.Id + "" + c.ClienteId + " " + c.Detalles)
                .ToLower()
                .Contains(Filtro.ToLower()
                )
                )
                .Select(c => c.ToResponse())
                .ToListAsync();
                return new Result<List<VentaResponse>>()
                {
                    Message = "OK",
                    Success = true,
                    Data = venta
                };
            }

            catch (Exception E)
            {

                return new Result<List<VentaResponse>>()
                {
                    Message = E.Message,
                    Success = false,
                };



            }
        }
    }

}
