using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Kochbuch
{
    public class ZutatModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int Menge { get; set; }
        public string Einheit { get; set; }
        public string Art { get; set; }
        
    }
}
