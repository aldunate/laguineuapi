using System.Collections.Generic;
using System.Web.Http;
using LaGuineuData;
using LaGuineuService.Services;
using System.Web.Http.Cors;

namespace LaguineuApi.Controllers
{
    [EnableCors("*","*","*")]
    public class UsuarioController : ApiController
    {
        // Curso
        private IUsuarioService usuarioService = new UsuarioService();
        private ITokenService tokenService = new TokenService();

        public List<UsuarioModel> Get()
        {
            Token token = (Token) Request.Properties["token"];
            return usuarioService.GetUsuariosEscuela(token.IdEscuela);
        }

        public Usuario Get(int id)
        {
            return usuarioService.GetUsuario(id);
        }

        public IHttpActionResult Post(Usuario usuario)
        {
            Token token = (Token)Request.Properties["token"];
            usuario.IdEscuela = token.IdEscuela;
            return Ok(usuarioService.EditarUsuario(usuario));
        }


    }
}