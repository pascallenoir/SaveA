using System;
using SQLite;

namespace SaveAll.Model
{
    [Table("Progammer")]
   public class Programmer
    {
        public int IdMembre{get;set;}
        public int IdEvenement { get; set; }
    }
}
