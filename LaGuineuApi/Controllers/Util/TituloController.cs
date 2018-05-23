using System.Collections.Generic;
using System.Web.Http;
using LaGuineuData;
using LaGuineuService.Services;
using System.Web.Http.Cors;
using System;

namespace LaGuineuApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class TituloController : ApiController
    {

        public IUtilService utilService = new UtilService();
        
        
        public List<Titulo> GetTitulos()
        {
            return utilService.GetTitulos();
        }

    }
}