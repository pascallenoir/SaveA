using SaveAll.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveAll.Helpers
{
    public static class TypeDocumentExtensions
    {
        /// <summary>
        /// Afficher la liste de tous les types documents
        /// </summary>
        /// <param name="bd"></param>
        /// <returns></returns>
        public static async Task<List<TypeDocument>> TousLesTypesDocumentsAsync(this DatabaseHelper bd)
        {
            return DatabaseHelper.sqliteconnection.Table<TypeDocument>().AsParallel().AsOrdered().ToList();
        }

        /// <summary>
        /// afficher un type document selon son id
        /// </summary>
        /// <param name="bd"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static async Task<TypeDocument> TypeDocumentByIdAsync(this DatabaseHelper bd, int Id)
        {
            return DatabaseHelper.sqliteconnection.Table<TypeDocument>().FirstOrDefault(t => t.IdTypeDocument == Id);
        }


        /// <summary>
        /// Supprimer tous les type documents
        /// </summary>
        /// <param name="bd"></param>
        public static async void SupprimerTousLesTypesDocumentsAsync(this DatabaseHelper bd)
        {
            DatabaseHelper.sqliteconnection.DeleteAll<TypeDocument>();
        }


        /// <summary>
        /// /supprimer un type document precis selon son id
        /// </summary>
        /// <param name="bd"></param>
        /// <param name="Id"></param>
        public static async void SupprimerTypeDocumentAsync(this DatabaseHelper bd, int Id)
        {
            DatabaseHelper.sqliteconnection.Delete<TypeDocument>(Id);
        }
    }
}
