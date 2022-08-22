using DesafioEntregable.Controllers.DTOS;
using DesafioEntregable.Repository;
using Microsoft.AspNetCore.Mvc;
namespace DesafioEntregable.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UsuarioController : ControllerBase
    {
       

        [HttpPut(Name = "ModificarUsuario")]
        public bool updateUser([FromBody] PutUsuario usuario)
        {
            return UsuarioHandler.modificarUsuario(usuario);

        }

        

    }
}
