namespace SaveAll.Model
{
    using System;
    using SQLite;

    [Table("Evenement")]
    public partial class Evenement
    {

          [PrimaryKey, AutoIncrement]
        public int id { get; set; }

       
        [MaxLength(50)]
        public string nomEvenement { get; set; }

        [MaxLength(50)]
        public string Lieu { get; set; }


        public DateTime DateDeb { get; set; }

        public TimeSpan HeureDeb { get; set; }


        public DateTime? DateFin { get; set; }

        public DateTime? ProchainEvenemt { get; set; }
        
       
        [MaxLength(254)]
        public string DescriptionEvenement { get; set; }

        public bool? Traite { get; set; }

        public DateTime? DateEnr { get; set; } = DateTime.Now;

        public DateTime? dateDerModif { get; set; } = DateTime.Now;

        [Indexed]
        public int? idTypeEv { get; set; }
        
    }
}
