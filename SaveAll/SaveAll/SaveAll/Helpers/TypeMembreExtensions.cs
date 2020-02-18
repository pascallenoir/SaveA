using SaveAll.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveAll.Helpers
{
    public static class TypeMembreExtensions
    {
        /// <summary>
        /// Afficher la liste de tous les types membres
        /// </summary>
        /// <param name="bd"></param>
        /// <returns></returns>
        public static async Task<List<TypeMembre>> TousLesTypesMembres(this DatabaseHelper bd)
        {
            return DatabaseHelper.sqliteconnection.Table<TypeMembre>().AsParallel().AsOrdered().ToList();
        }

        /// <summary>
        /// Afficher un type membre par id
        /// </summary>
        /// <param name="bd"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static async Task<TypeMembre> TypeMembreById(this DatabaseHelper bd, int Id)
        {
            return DatabaseHelper.sqliteconnection.Table<TypeMembre>().AsParallel().FirstOrDefault(t => t.IdTypeMembre == Id);
        }

        /// <summary>
        /// supprimer tous les types de membre
        /// </summary>
        /// <param name="bd"></param>
        public static async void SupprimerTousLesTypesMembres(this DatabaseHelper bd)
        {
            DatabaseHelper.sqliteconnection.DeleteAll<TypeMembre>();
        }

        /// <summary>
        /// supprimer un type membre par id
        /// </summary>
        /// <param name="bd"></param>
        /// <param name="Id"></param>
        public static async void SupprimerTypeMembre(this DatabaseHelper bd, int Id)
        {
            DatabaseHelper.sqliteconnection.Delete<TypeMembre>(Id);
        }
    }
}
