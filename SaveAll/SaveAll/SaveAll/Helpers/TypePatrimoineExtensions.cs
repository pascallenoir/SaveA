using SaveAll.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveAll.Helpers
{
    public static class TypePatrimoineExtensions
    {
        /// <summary>
        /// afficher la liste de tous les types patrimoines
        /// </summary>
        /// <param name="bd"></param>
        /// <returns></returns>
        public static async Task<List<TypePatrimoine>> TousLesTypesPatrimoines(this DatabaseHelper bd)
        {
            return DatabaseHelper.sqliteconnection.Table<TypePatrimoine>().AsParallel().AsOrdered().ToList();
        }

        /// <summary>
        /// Afficher un type patrimoine par id
        /// </summary>
        /// <param name="bd"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static async Task<TypePatrimoine> TypePatrimoineById(this DatabaseHelper bd, int Id)
        {
            return DatabaseHelper.sqliteconnection.Table<TypePatrimoine>().AsParallel().FirstOrDefault(t => t.IdTypePatrimoine == Id);
        }

        /// <summary>
        /// Supprimer tous les types patrimoines 
        /// </summary>
        /// <param name="bd"></param>
        public static async void SupprimerTousLesTypesPatrimoines(this DatabaseHelper bd)
        {
            DatabaseHelper.sqliteconnection.DeleteAll<TypePatrimoine>();
        }

        /// <summary>
        /// supprimer un patrimoine par id
        /// </summary>
        /// <param name="bd"></param>
        /// <param name="Id"></param>

        public static async void SupprimerTypePatrimoine(this DatabaseHelper bd, int Id)
        {
            DatabaseHelper.sqliteconnection.Delete<TypePatrimoine>(Id);
        }
    }
}
