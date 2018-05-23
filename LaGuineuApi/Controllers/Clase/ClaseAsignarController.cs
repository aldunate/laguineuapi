using System.Collections.Generic;
using System.Web.Http;
using LaGuineuData;
using LaGuineuService.Services;
using System.Web.Http.Cors;
using System;

namespace LaGuineuApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ClaseAsignarController : ApiController
    {

        public IClaseService claseService = new ClaseService();
        public ITokenService tokenService = new TokenService();

        
        public int PostClase(ClaseModel clase)
        {
            Token token = (Token)Request.Properties["token"];
            return claseService.PostAsignada(clase);
        }

    }
}