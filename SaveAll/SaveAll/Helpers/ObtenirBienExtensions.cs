using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SaveAll.Model;

namespace SaveAll.Helpers
{
    public static class ObtenirBienExtensions
    {
        /// <summary>
        /// Permet de lier un bien à son(ses) propriétaires.
        /// </summary>
        /// <example>
        /// <code>
        /// Membre membre = new Membre();
        /// membre.AttribuerDocument(patrimoine)
        /// 
        /// </code>
        /// </example>
        /// <param name="membre">Notre membre Concerné.</param>
        /// <param name="patrimoine">Le type de type l'évenement de notre événement .</param>
        public static void AttribuerPatrimoine(this Membre membre, Patrimoine patrimoine)
        {
            var ObtenirBien = new ObtenirBien()
            {
                IdPatrimoine = patrimoine.Id,
                IdMembre = membre.Id
            };
            DatabaseHelper.sqliteconnection.Insert(ObtenirBien);

        }



        /// <summary>
        /// Permet d'attribuer un propriétaires à un bien.
        /// </summary>
        /// <example>
        /// <code>
        /// Patrimoine patrimoine = new Patrimoine();
        /// Patrimoine.AjouterProporiétaire(membre)
        /// 
        /// </code>
        /// </example>
        /// <param name="membre">Notre membre Concerné.</param>
        /// <param name="patrimoine">Le type de type l'évenement de notre événement .</param>
        public static void AjouterProporiétaire(this Patrimoine patrimoine, Membre membre)
        {
            var ObtenirBien = new ObtenirBien()
            {
                IdPatrimoine = patrimoine.Id,
                IdMembre = membre.Id
            };
            DatabaseHelper.sqliteconnection.Insert(ObtenirBien);

        }

        /// <summary>
        /// Permet de réccupérer les biens attribués à un membre
        /// </summary>
        /// <example>
        /// <code>
        /// List<Patrimoine> patrimoine = membre.SesBiens();
        ///  
        /// </code>
        /// </example>
        /// <param name="membre">Notre membre Concerné.</param>

        public static async Task<List<Patrimoine>> SesBiens(this Membre membre)
        {
            var result = new List<Patrimoine>();
            foreach (var tmp in DatabaseHelper.sqliteconnection.Table<ObtenirBien>().Where(t => t.IdMembre == membre.Id).ToList())
            {
                result.Add(await tmp.GetPatrimoine());
            }
            return result;


        }




        /// <summary>
        /// Permet de réccupérer les Membres liés à un bien
        /// </summary>
        /// <example>
        /// <code>
        /// List<Membre> membres = Patrimoine.SesProprietaires();
        ///  
        /// </code>
        /// </example>
        /// <param name="patrimoine">Notre bien concerné.</param>
        public static List<Membre> SesProprietaires(this Patrimoine patrimoine)
        {
            var result = new List<Membre>();
            foreach (var tmp in DatabaseHelper.sqliteconnection.Table<ObtenirBien>().Where(t => t.IdPatrimoine == patrimoine.Id).ToList())
            {
                result.Add(tmp.GetMembre());
            }
            return result;

        }
        /// <summary>
        ///Supprimmer toutes les liaisons à un bien
        /// </summary>
        /// <example>
        /// <code>
        /// List<Membre> membres = bien.SupprimerTouteProprieté();
        ///  
        /// </code>
        /// </example>
        /// <param name="patrimoine">Notre bien concerné.</param>
        public static void SupprimerTouteProprieté(this DatabaseHelper bd)
        {
            DatabaseHelper.sqliteconnection.DeleteAll<ObtenirBien>();
        }

        private static async Task<Patrimoine> GetPatrimoine(this ObtenirBien o)
        {
            return await new DatabaseHelper().PatrimoineById(o.IdPatrimoine);

        }
        private static Membre GetMembre(this ObtenirBien o)
        {
            return new DatabaseHelper().MembreById(o.IdMembre);
        }

        private static List<ObtenirBien> ListeObtenirBien(this DatabaseHelper bd)
        {
            return DatabaseHelper.sqliteconnection.Table<ObtenirBien>().ToList();

        }

    }
}
