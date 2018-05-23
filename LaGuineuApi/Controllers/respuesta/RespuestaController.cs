using System.Collections.Generic;
using System.Web.Http;
using LaGuineuData;
using LaGuineuService.Services;
using System.Web.Http.Cors;
using System;
using System.Net.Http;
using System.Net.Http.Headers;


namespace LaGuineuApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class RespuestaController : ApiController
    {
       
        // GET: Monitor
        public Object GetDeportes()
        {
            return null;
        }

        public Object GetDeportes(int idEscuela)
        {
            return null;
        }


    }
}