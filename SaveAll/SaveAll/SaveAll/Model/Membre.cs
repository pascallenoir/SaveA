namespace SaveAll.Model
{
    using System;
    using SQLite;

    [Table("Membre")]
    public partial class Membre
    {

          [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int? Mem_id { get; set; }

       
        [MaxLength(30)]
        public string Nom { get; set; }

       
        [MaxLength(50)]
        public string Prenom { get; set; }

        public DateTime DateNaiss { get; set; }

        [MaxLength(1)]
        public string Sexe { get; set; }

        [MaxLength(70)]
        public string LieuNaiss { get; set; }

        [MaxLength(70)]
        public string Profession { get; set; }


        [MaxLength(3)]
        public string GroupeSanguin { get; set; }

        [MaxLength(30)]
        public string Telephone { get; set; }

        [MaxLength(30)]
        public string Telephone2 { get; set; }

        [MaxLength(70)]
        public string Adresse { get; set; }

        [MaxLength(70)]
        public string Adresse2 { get; set; }

        [MaxLength(50)]
        public string Nationalite { get; set; }

        


        /// <summary>
        /// information de connexion et inscription utilisateur
        /// </summary>

        [MaxLength(30)]
        public string Login { get; set; }

        public string Pass { get;  set; }

        

        /// <summary>
        /// fin de connexion et inscription utilisateur
        /// </summary>
        ///

        


        [MaxLength(100)]
        public string QuestionPiege { get; set; }

        [MaxLength(100)]
        public string Reponse { get; set; }

        public bool Principal { get; set; } = false;


        public DateTime? DateEnr { get; set; } = DateTime.Now;

        public DateTime? DateDerModif { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string TypeEnr { get; set; }

       
        public byte[] Photo { get; set; }

        [Indexed]
        public int? IdTypeMem { get; set; }





    }
}
