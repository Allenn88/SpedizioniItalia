using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpedizioniItalia.Models
{
    public class Spedizione
    {
        public int IDSpedizione { get; set; }
        public DateTime DataSpedizione { get; set; }
        public decimal Peso { get; set; }
        public string Citta { get; set; }
        public string Indirizzo { get; set; }
        public decimal CostoSpedizione { get; set; }
        public DateTime? DataConsegna { get; set; }
        public int IDCliente { get; set; }
        public int IDAzienda { get; set; }
        public int IDStato { get; set; }
    }
}