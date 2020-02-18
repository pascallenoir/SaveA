using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveAll.Model
{
    [Table("TypeDocument")]
    public partial class TypeDocument
    {


        [PrimaryKey, AutoIncrement]
        public int IdTypeDocument { get; set; }


        [MaxLength(30)]
        public string NomTypeDocument { get; set; }


    }
}
