using System;
using SQLite;

namespace SaveAll.Model
{
    public enum MediaFileType
    {
        Image,
        Video
    }


    [Table("Patrimoine")]
    public partial class Patrimoine
    {
        
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int? Patrim_id { get; set; }


        [MaxLength(50)]
        public string NomDuBien { get; set; }

        [MaxLength(50)]
        public string NumeroDuBien { get; set; }

        [MaxLength(254)]
        public string DescriptionPatrimoine { get; set; }


        public DateTime? DateAcquisition { get; set; }

        [MaxLength(70)]
        public string ValeurAcquisition { get; set; }

        [MaxLength(70)]
        public string ValeurActuel { get; set; }

        public DateTime? DateEnr { get; set; } = DateTime.Now;

        public DateTime? DateDerModif { get; set; } = DateTime.Now;

        [Indexed]
        public int? idTypePat { get; set; }

        public string MyPosition { get; set; }


        public string PreviewPath { get; set; }
        public string Path { get; set; }
        public MediaFileType Type { get; set; }


    }


}
