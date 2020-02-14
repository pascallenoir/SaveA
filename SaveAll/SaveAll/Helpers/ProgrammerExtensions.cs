using SaveAll.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveAll.Helpers
{
   public static class ProgrammerExtensions
    {

        /// <summary>
        /// Permet de Permet de programmer un Evenement pour membre.
        /// </summary>
        /// <example>
        /// <code>
        /// Evenement evenement = new Evenement();
        /// membre.AjouterEvenement(evenement)
        /// 
        /// </code>
        /// </example>
        /// <param name="membre">Notre événement Concerné.</param>
        /// <param name="evenement">l'évenement à Enregistrer.</param>

        public static void AjouterEvenement(this Membre membre, Evenement evenement)
        {
            var programmer = new Programmer()
            {
                IdEvenement = evenement.id,
                IdMembre = membre.Id
            };
            membre.DateDerModif = DateTime.Now;
            DatabaseHelper.sqliteconnection.Insert(programmer);

        }

        #region fonction privées
        private static List<Programmer> ListeProgrammes(this DatabaseHelper bd)
        {
           return DatabaseHelper.sqliteconnection.Table<Programmer>().ToList();
           
        }
      
        private static List<Programmer> ProgrammerByMembres(this Membre Id )
        {
            return DatabaseHelper.sqliteconnection.Table<Programmer>().Where(t => t.IdMembre == Id.Id).ToList();
         
        }
        private static List<Programmer> ProgrammesByEvent(this Evenement Id)
        {
            return DatabaseHelper.sqliteconnection.Table<Programmer>().Where(t => t.IdEvenement == Id.id).ToList();

        }
        #endregion

        public static async  void SupprimerTousLesProgrammesAsync(this DatabaseHelper bd)
        {
            DatabaseHelper.sqliteconnection.DeleteAll<Programmer>();
        }
        /// <summary>
        /// Permet de récuppérer la liste des Evenements d'un membre.
        /// </summary>
        /// <example>
        /// <code>
        /// membre.SesEvenements();
        /// 
        /// </code>
        /// </example>
        /// <param name="membre">Notre membre dont nous voulons les évenements.</param>

        public static async Task<List<Evenement>> SesEvenementsAsync(this Membre membre)
        {
            List<Evenement> result = new List<Evenement>();
            var liste = membre.ProgrammerByMembres();
            Parallel.ForEach(liste, (prog) =>
            {
                var tmp  = new DatabaseHelper().EvenementById(prog.IdEvenement);
                result.Add(tmp);
            });
            return result;
           
        }
        /// <summary>
        /// Permet de récuppérer la liste des membres d'un événements.
        /// </summary>
        /// <example>
        /// <code>
        /// membre.SesEvenements();
        /// 
        /// </code>
        /// </example>
        /// <param name="evenement">Notre événement dont nous voulons les Membres.</param>

        public static async  Task<List<Membre>> SesMembresAsync(this Evenement evenement)
        {

            var listeProgramme = evenement.ProgrammesByEvent();
            var result = new List<Membre>();
            foreach (var prog in listeProgramme)
            {
                result.Add(new DatabaseHelper().MembreById(prog.IdMembre));
            }
            return result;
        }

    }
}
