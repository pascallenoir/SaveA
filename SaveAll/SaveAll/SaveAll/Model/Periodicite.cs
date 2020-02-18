using System;
using SQLite;

namespace SaveAll.Model
{
    [Table("Periodicite")]
    public class Periodicite
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(30)]
        public string Valeur { get; set; }
            
        public Periodicite(SaveAll.Model.Enums.Periodicite periodicite)
        {
            ID = (int)periodicite;
            Valeur = periodicite.ToString();
        }
        public Periodicite()
        {
            ID = 0;
            Valeur = string.Empty;
        }

    }
}
  