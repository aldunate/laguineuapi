using System.Collections.Generic;
using System.Web.Http;
using LaGuineuData;
using LaGuineuService.Services;
using System.Web.Http.Cors;
using System;

public class PostEscuela
{
    public Escuela Escuela { get; set; }
    public Usuario Usuario { get; set; }
}

namespace LaGuineuApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class EscuelaController : ApiController
    {

        public IEscuelaService escuelaService = new EscuelaService();
        public IUsuarioService usuarioService = new UsuarioService();

        public EscuelaModel GetEscuela()
        {
            Token token = (Token)Request.Properties["token"];
            return escuelaService.GetEscuela(token.IdEscuela);
        }

        public EscuelaModel Post(EscuelaModel escuela) // List<MonitorTitulo> titulos
        {
            Token token = (Token)Request.Properties["token"];
            if(escuela.Escuela == null)
            {
                escuela.Escuela = new Escuela();
                escuela.Escuela.Id = token.IdEscuela;
            }
            return escuelaService.EditarEscuela(escuela);
        }
    }
}