using SaveAll.Model;
using SaveAll.ViewModel.ViewModelUtilisateur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveAll.Helpers
{
    public static class MembreExtensions
    {
        /// <summary>
        /// Permet de Réccupérer la liste de tous les mmebres enrégistrés
        /// </summary>
        public static async Task<List<Membre>> ListeMembreAsync(this DatabaseHelper bd)
        {
            return DatabaseHelper.sqliteconnection.Table<Membre>().AsParallel().ToList();
        }


        /// <summary>
        /// verifier si un utilisateur existe deja dans la table membre
        /// </summary>
        /// <returns></returns>

        public static int nombreMembre()
        {
            return DatabaseHelper.sqliteconnection.Table<Membre>().AsParallel().ToList().Count;
        }

        /// <summary>
        /// Permet de Réccupérer la liste de tous les mmebres fils d'un membre
        /// </summary>
        public static async Task<List<Membre>> EnfantsAsync(this Membre membre)
        {
            return DatabaseHelper.sqliteconnection.Table<Membre>().AsParallel().Where(p => p.Mem_id == membre.Id).ToList();
        }


        /// <summary>
        /// supprimer tous les membres
        /// </summary>
        /// <param name="bd"></param>
        /// <returns></returns>

        public static async Task SupprimerTousLesMembreAsync(this DatabaseHelper bd)
        {
            DatabaseHelper.sqliteconnection.DeleteAll<Membre>();
        }

        /// <summary>
        /// supprimer un doc par id
        /// </summary>
        /// <param name="bd"></param>
        /// <param name="Id"></param>
        /// <returns></returns>

        public static async Task SupprimerMembreAsync(this DatabaseHelper bd, int Id)
        {
            DatabaseHelper.sqliteconnection.Delete<Membre>(Id);
        }

        /// <summary>
        /// Permet de Réccupérer membres connaissant son Id
        /// </summary>

        public static Membre MembreById(this DatabaseHelper bd, int Id)
        {
            return DatabaseHelper.sqliteconnection.Table<Membre>().FirstOrDefault(p => p.Id == Id);
        }
        /// <summary>
        /// Permet de Réccupérer le Membre principal de l'Application
        /// </summary>

        public static Membre MembreById(this DatabaseHelper bd)
        {
            return DatabaseHelper.sqliteconnection.Table<Membre>().FirstOrDefault(p => p.Principal);
          
        }



        /// <summary>
        /// script de connexion utilisateur
        /// </summary>
        /// <param name="membre"></param>
        /// <returns></returns>

        public static bool LoginIsValid(this Membre membre)
        {
            string passHash = membre.Pass.EncodeMd5();

           var user = DatabaseHelper.sqliteconnection.Table<Membre>().FirstOrDefault(p => p.Login == membre.Login && p.Pass== passHash);

            membre = user??membre;

            App.MembreActuel = App.user = membre;
            return user != null;

        }


        /// <summary>
        /// script pour verifier la reponse de utilisateur dans mot de passe oublie
        /// </summary>
        /// <param name="membre"></param>
        /// <returns></returns>

        public static bool ReponseIsValid(this Membre membre)
        {
            
            var user = DatabaseHelper.sqliteconnection.Table<Membre>().FirstOrDefault(p => p.Reponse == membre.Reponse);

            membre = user ?? membre;

            return user != null;

        }



        /// <summary>
        /// script pour verifer si le nom utilisateur existe dans la base de donnee
        /// </summary>
        /// <param name="membre"></param>
        /// <returns></returns>

        public static bool UsernameIsValid(this Membre membre)
        {

            var user = DatabaseHelper.sqliteconnection.Table<Membre>().FirstOrDefault(p => p.Login == membre.Login);

            membre = user ?? membre;

            return user != null;

        }



        public static bool PaswordIsValid(this Membre membre)
        {

            var user = DatabaseHelper.sqliteconnection.Table<Membre>().FirstOrDefault(p => p.Pass == membre.Pass);

            membre = user ?? membre;

            return user != null;

        }



        /// <summary>
        /// script pour comparer le mot de passe avant mise a jour
        /// </summary>
        /// <param name="membreModifPassword"></param>
        /// <returns></returns>

        public static bool PaswordIsValidForChange(this MembreModifPassword membreModifPassword)
        {
            string passHashverify = membreModifPassword.PassActuel.EncodeMd5();

            var code = DatabaseHelper.sqliteconnection.Table<Membre>().FirstOrDefault(p => p.Pass == passHashverify);

            return code != null;

        }


    }
}
