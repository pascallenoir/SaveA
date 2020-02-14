using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveAll.Model
{

    [Table("TypePatrimoine")]
    public partial class TypePatrimoine
    {


        [PrimaryKey, AutoIncrement]
        public int IdTypePatrimoine { get; set; }


        [MaxLength(30)]
        public string NomTypePatrimoine { get; set; }


    }
}
