using System.Collections.Generic;

namespace LaGuineuData
{
    public class UsuarioModel:Usuario
    {
        public int IdMonitor { get; set; }
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
    }
    
}