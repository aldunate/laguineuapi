using LaGuineuData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaGuineuService.Services
{ 
    public interface IEstacionService
    {
        List<Estacion> GetEstaciones();
        List<EscuelaEstacion> GetEstacionEscuela(int idEscuela);
    }
}