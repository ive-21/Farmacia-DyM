using FarmaciaDyM.Data.Context;
using FarmaciaDyM.Data.Entities;
using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaDyM.Data.Services
{

    public class Resulttando
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
    public class Resulttando<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }



    public class VentaServices : IVentaServices
    {
        private readonly IMyDbContext dbContext;

        public VentaServices(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
            {

            }

        }

        public async Task<Result> Crear(VentasRequest request)
        {
            try
            {
                var venta = Venta.crear(request);

                dbContext.Ventas.Add(venta);
                await dbContext.SaveChangesAsync();
                return new Result() { message = "OK", Succes = true };

            }

            catch (Exception E)
            {

                return new Result() { message = E.Message, Succes = false };
            }

        }

        public async Task<Result> MOdificar(VentasRequest request)
        {
            try
            {
                var venta = await dbContext.Ventas.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (venta == null)
                    return new Result() { message = "No se Encontro La Venta", Succes = false };
                if (venta.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { message = "OK", Succes = true };




            }

            catch (Exception E)
            {

                return new Result() { message = E.Message, Succes = false };
            }
        }

        public async Task<Result> Eliminar(VentasRequest request)
        {
            try
            {
                var venta = await dbContext.Ventas.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (venta == null)
                    return new Result() { message= "No se Encontro El Producto", Succes = false };
                dbContext.Ventas.Remove(venta);
                await dbContext.SaveChangesAsync();
                return new Result() { message= "OK", Succes = true };


            }

            catch (Exception E)
            {

                return new Result() { message = E.Message, Succes = false };
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
                    Succes = true,
                    Data = venta
                };
            }

            catch (Exception E)
            {

                return new Result<List<VentaResponse>>()
                {
                    Message = E.Message,
                    Succes= false,
                };



            }
        }
    }

}
