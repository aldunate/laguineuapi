using LaGuineuData;
using System.Collections.Generic;

namespace LaGuineuService.Services
{ 
    public interface IEscuelaService
    {
        EscuelaModel GetEscuela(int id);
        EscuelaModel EditarEscuela(EscuelaModel escuela);
        int GuardarPerfil(int idEscuela, string fotoPerfil);
    }
}