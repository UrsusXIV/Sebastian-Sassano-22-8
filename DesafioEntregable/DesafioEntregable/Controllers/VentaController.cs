using DesafioEntregable.Controllers.DTOS;
using DesafioEntregable.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DesafioEntregable.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class VentaController : ControllerBase
    {


        [HttpPost(Name = "CrearVenta")]
        public bool crearVenta([FromBody] PostVenta venta)
        {
            return VentaHandler.insertarVenta(venta);

            for(int i = 1; i < venta._productosVendidos.Count; i++)
            {
                // intentaría insertar en productoVendido y actualizar el stock en Producto

            }
            

        }



    }
}
