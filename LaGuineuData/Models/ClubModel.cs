using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaGuineuData;

namespace LaGuineuData
{
    public class ClubModel
    {
        public Club Club { get; set; }
        public List<Cliente> Clientes { get; set; }
        public string Operacion { get; set; }
    }
}