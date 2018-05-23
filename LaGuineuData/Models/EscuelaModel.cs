using System.Collections.Generic;

namespace LaGuineuData
{
    public class EscuelaModel
    {
        public Escuela Escuela { get; set; }
        public List<EscuelaDisponible> FechasDisponibles { get; set; }
        public List<EscuelaEsModel> EstacionesDisponibles { get; set; }
        public List<EscuelaDeporte> DeportesDisponibles { get; set; }
        public string Operacion { get; set; }
    }

    public class EscuelaEsModel: EscuelaEstacion  {
        public string Nombre { get; set; }
    }


}