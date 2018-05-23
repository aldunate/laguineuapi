using System.Collections.Generic;
using System.Web.Http;
using LaGuineuData;
using LaGuineuService.Services;
using System.Web.Http.Cors;

namespace LaGuineuApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class TokenController : ApiController
    {
        // Curso
        private IUtilService utilService = new UtilService();
        private ITokenService tokenService = new TokenService();

        public bool GetToken()
        {
            return true;
        }



    }
}