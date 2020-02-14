using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaveAll.Model;

namespace SaveAll.Helpers
{
    public static class PatrimoineExtensions
    {

        /// <summary>
        /// recuperer la liste du patrimoine utilisateur
        /// </summary>
        /// <param name="bd"></param>
        /// <returns></returns>
        public static async Task<List<Patrimoine>> TousLePatrimoine(this DatabaseHelper bd)
        {
            return DatabaseHelper.sqliteconnection.Table<Patrimoine>().AsParallel().ToList();

        }


        /// <summary>
        /// recuperer le patrimoine utilisateur par son id
        /// </summary>
        /// <param name="bd"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static async Task<Patrimoine> PatrimoineById(this DatabaseHelper bd, int Id)
        {
            return DatabaseHelper.sqliteconnection.Table<Patrimoine>().AsParallel().FirstOrDefault(t => t.Id == Id);
        }


        /// <summary>
        /// supprimer tous le patrimoine utilisateur
        /// </summary>
        /// <param name="bd"></param>
        /// <returns></returns>

        public static async Task SupprimerTousLePatrimoineAsync(this DatabaseHelper bd)
        {
            DatabaseHelper.sqliteconnection.DeleteAll<Patrimoine>();
        }

        /// <summary>
        /// supprimer un bien par son id
        /// </summary>
        /// <param name="bd"></param>
        /// <param name="Id"></param>
        /// <returns></returns>

        public static async Task SupprimerPatrimoineById(this DatabaseHelper bd, int Id)
        {
            DatabaseHelper.sqliteconnection.Delete<Patrimoine>(Id);
        }



     

    }
}
