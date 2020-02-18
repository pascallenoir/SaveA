using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveAll.Model
{
    [Table("TypeMembre")]
    public partial class TypeMembre
    {


        [PrimaryKey, AutoIncrement]
        public int IdTypeMembre { get; set; }


        [MaxLength(30)]
        public string NomTypeMembre { get; set; }


    }
}
