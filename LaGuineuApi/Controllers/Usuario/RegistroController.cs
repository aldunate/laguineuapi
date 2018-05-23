using System.Collections.Generic;
using System.Web.Http;
using LaGuineuData;
using LaGuineuService.Services;
using System.Web.Http.Cors;

namespace LaguineuApi.Controllers
{
    [EnableCors("*","*","*")]
    public class RegistroController : ApiController
    {
        // Curso
        private IUsuarioService usuarioService = new UsuarioService();

        public Usuario Get(string nombre)
        {
            return usuarioService.GetUsuario(nombre);
        }

    }
}