using System.Collections.Generic;
using System.Web.Http;
using LaGuineuData;
using LaGuineuService.Services;
using System.Web.Http.Cors;
using System;

namespace LaGuineuApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ClaseController : ApiController
    {

        public IClaseService claseService = new ClaseService();
        public ITokenService tokenService = new TokenService();

        // GET: Monitor
        public Object Get(int id)
        {
            return claseService.GetClase(id);
        }

        public Object GetClases(string operacion,string fecha)
        {
            Token token = (Token) Request.Properties["token"];
            if(operacion == "Todas")
            {
                return claseService.GetClaseEscuela(token.IdEscuela);

            }
            if (operacion == "Fecha")
            {
                return claseService.GetClaseEscuelaFecha(token.IdEscuela,fecha);

            }
            return null;

        }

        public int PostClase(Clase clase)
        {
            Token token = (Token)Request.Properties["token"];
            clase.IdEscuela = token.IdEscuela;
            return claseService.PostClase(clase).Id;
        }

    }
}