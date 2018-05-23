using System.Collections.Generic;
using System.Web.Http;
using LaGuineuData;
using LaGuineuService.Services;
using System.Web.Http.Cors;

namespace LaGuineuApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class NivelController : ApiController
    {
        // Curso
        private IUtilService utilService = new UtilService();

        public List<Nivel> GetNiveles()
        {
            return utilService.GetNiveles();
        }



    }
}