using System.Collections.Generic;
using System.Web.Http;
using LaGuineuData;
using LaGuineuService.Services;
using System.Web.Http.Cors;
using System.Security.Claims;

namespace LaGuineuApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AuthController : ApiController
    {
        ITokenService tokenService = new TokenService();
        IUsuarioService usuarioService = new UsuarioService();


        // Autentificacion devuelve token
        public string Post(Usuario usuario)
        {
            usuario = usuarioService.GetUsuario(usuario.Id);
            if(usuario != null) return tokenService.CreateToken(usuario).Nombre;
            return "El usuario no existe";
        }

    }
}