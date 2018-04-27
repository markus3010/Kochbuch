using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Kochbuch
{
    public class RezeptModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Titel { get; set; }
        public schwierigkeit Schwierigkeit { get; set; }
        public string Autor { get; set; }
        [Ignore]
        public List<ZutatModel> Zutaten { get; set; }
        public string Beschreibung { get; set; }


        public enum schwierigkeit
        {
            Leicht,
            Mittel,
            Schwer
        }
    }
    
}
