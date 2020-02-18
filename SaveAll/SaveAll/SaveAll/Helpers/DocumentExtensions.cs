using SaveAll.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveAll.Helpers
{
    public static class DocumentExtensions
    {
        // <summary>
        // Affecter un type de document a un utilisateur
        // </summary>
        // <param name="Document"></param>
        // <param name="typeDocument"></param>

        public static async  void AffecterTypeDocumentAsync(this Document Document, TypeDocument typeDocument)
        {
          
            Document.DateDerModif = DateTime.Now;
            Document.IdTypeDoc = typeDocument.IdTypeDocument;
            
        }

        // <summary>
        // Liste de tous les documeents
        // </summary>
        // <param name="bd"></param>
        // <returns></returns>

        public static async Task<List<Document>>TousLesDocuments(this DatabaseHelper bd)
        {
            return DatabaseHelper.sqliteconnection.Table<Document>().AsParallel().ToList();

        }

        /// <summary>
        /// recuperer un document par son id
        /// </summary>
        /// <param name="bd"></param>
        /// <param name="Id"></param>
        /// <returns></returns>

        public static async Task<Document> DocumentByIdAsync(this DatabaseHelper bd, int Id)
        {
            return DatabaseHelper.sqliteconnection.Table<Document>().AsParallel().FirstOrDefault(t => t.Id == Id);
         }


        /// <summary>
        /// supprimer tous les documents
        /// </summary>
        /// <param name="bd"></param>
        /// <returns></returns>

        public static async Task SupprimerTousLesDocumentsAsync(this DatabaseHelper bd)
        {
            DatabaseHelper.sqliteconnection.DeleteAll<Document>();
        }


        /// <summary>
        /// supprimer un document par id
        /// </summary>
        /// <param name="bd"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static async Task SupprimerDocumentsAsync(this DatabaseHelper bd, int Id)
        {
             DatabaseHelper.sqliteconnection.Delete<Document>(Id);
        }


    }
}
