using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Kochbuch
{
    public class RezeptZutatVerbindung
    {
        [AutoIncrement,PrimaryKey]
        public int ID { get; set; }
        public int RezeptID { get; set; }
        public int ZutatID { get; set; }
        
    }
}
