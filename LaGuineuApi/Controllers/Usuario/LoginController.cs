using System.Collections.Generic;
using System.Web.Http;
using LaGuineuData;
using LaGuineuService.Services;
using System.Web.Http.Cors;

namespace LaguineuApi.Controllers
{
    [EnableCors("*","*","*")]
    public class LoginController : ApiController
    {
        // Curso
        private IUsuarioService usuarioService = new UsuarioService();

        

        public IHttpActionResult Post(Usuario usuario)
        {
            return Ok(usuarioService.LoginUsuario(usuario));
        }


    }
}