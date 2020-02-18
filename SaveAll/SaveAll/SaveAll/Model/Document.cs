namespace SaveAll.Model
{
    using System;
    using System.Collections.Generic;
    using SQLite;

    [Table("Document")]
    public partial class Document
    {
        

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int? Doc_id { get; set; }


        [MaxLength(50)]
        public string nomDocument { get; set; }


        [MaxLength(50)]
        public string Code { get; set; }

        public bool? Periodicite { get; set; }

        [MaxLength(254)]
        public string DescriptionDocument { get; set; }

        public DateTime DateEts { get; set; }

        public DateTime DateExp { get; set; }

        public TimeSpan HeureExp { get; set; }

        [MaxLength(70)]
        public string Organisme { get; set; }

        public DateTime? DateEnr { get; set; } = DateTime.Now;

        public DateTime? DateDerModif { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string TypeEnr { get; set; }


        public byte[] Photo { get; set; }


        public byte[] Fichier { get; set; }
        public string NomduFichier { get; set; }
        public string AccesFichier { get; set; }

        [Indexed]
        public int? IdEvenement { get; set; }

        [Indexed]
        public int? IdTypeDoc { get; set; }

    }
}
