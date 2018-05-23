using System.Collections.Generic;

namespace LaGuineuData
{
    public class ClaseModel
    {
        public Clase Clase { get; set; }
        public List<ClaseMonitor> Monitores { get; set; }
        public List<ClaseCliente> Clientes { get; set; }
    }
    
}