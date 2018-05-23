using LaGuineuData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaGuineuService.Services
{ 
    public interface IUtilService
    {
        List<Nivel> GetNiveles();
        List<Titulo> GetTitulos();
    }
}