using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpedizioniItalia.Models
{
    public class Stato
    {
        public int IDStato { get; set; }
        public string Descrizione { get; set; }
        public DateTime Data { get; set; }
        public int IDSpedizione { get; set; }
    }
}