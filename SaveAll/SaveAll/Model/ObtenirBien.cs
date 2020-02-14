using System;
using SQLite;

namespace SaveAll.Model
{

    [Table("ObtenirBien")]
    public class ObtenirBien
    {
        public int IdMembre { get; set; }
        public int IdPatrimoine { get; set; }
    }
}
