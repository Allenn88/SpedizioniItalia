using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpedizioniItalia.Models
{
    public class Cliente
    {
        public int IDCliente { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
    }

}