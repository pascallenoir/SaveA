namespace SaveAll.Model
{
    using System;
    using SQLite;
    

    [Table("TypeEvenement")]
    public partial class TypeEvenement
    {
        
         [PrimaryKey, AutoIncrement]
        public int IdTypeEvenement { get; set; }

       
        [MaxLength(30),Unique]

        public string Nom { get; set; }

        public int IDPeriodicite { get; set; }

    }
}
