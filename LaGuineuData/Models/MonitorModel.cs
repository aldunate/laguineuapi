using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaGuineuData;

namespace LaGuineuData
{
    public class MonitorModel
    {
        public Monitor Monitor { get; set; }
        public List<MonitorDisponible> FechasDisponibles { get; set; }
        public List<MonitorEstacion> EstacionesDisponibles { get; set; }
        public List<MonitorTitulo> Titulos { get; set; }
        public Usuario Usuario { get; set; }
        public string Operacion { get; set; }
    }
}