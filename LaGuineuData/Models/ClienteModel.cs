using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaGuineuData;

namespace LaGuineuData
{
    public class ClienteModel
    {
        public Cliente Cliente { get; set; }
        public Usuario Usuario { get; set; }
        public string Operacion { get; set; }
    }
}