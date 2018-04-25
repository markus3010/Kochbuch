using System;
using System.Collections.Generic;
using System.Text;

namespace Kochbuch
{
    public class RezeptModel
    {
        public string titel;
        public Schwierigkeit schwierigkeit;
        public string autor;
        public List<ZutatModel> zutaten;
        public string beschreibung;


        public enum Schwierigkeit
        {
            Leicht,
            Mittel,
            Schwer
        }
    }
    
}
