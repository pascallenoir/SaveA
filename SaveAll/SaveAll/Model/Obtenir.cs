using System;
using SQLite;
using System.Text;

namespace SaveAll.Model
{
    [Table("Obtenir")]
    public class Obtenir
    {
        public int IdMembre { get; set; }
        public int IdDocument { get; set; }
    }
}
