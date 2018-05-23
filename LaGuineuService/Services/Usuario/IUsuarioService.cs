using LaGuineuData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaGuineuService.Services
{
    public interface IUsuarioService
    {
        List<UsuarioModel> GetUsuariosEscuela(int idEscuela);
        Usuario GetUsuario(int id);
        Usuario GetUsuario(string nombre);
        string EditarUsuario(Usuario usuario);
        Token LoginUsuario(Usuario usuario);


    }
}