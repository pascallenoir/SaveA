using SaveAll.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveAll.Helpers
{
    public static class ObtenirExtension
    {
        /// <summary>
        /// Permet de lier un un document à son(ses) propriétaires.
        /// </summary>
        /// <example>
        /// <code>
        /// Membre membre = new Membre();
        /// membre.AttribuerDocument(document)
        /// 
        /// </code>
        /// </example>
        /// <param name="membre">Notre membre Concerné.</param>
        /// <param name="document">Le type de type l'évenement de notre événement .</param>
        public static void AttribuerDocument (this Membre membre, Document document)
        {
            var Obtenir = new Obtenir()
            {
                IdDocument = document.Id,
                IdMembre = membre.Id
            };
            DatabaseHelper.sqliteconnection.Insert(Obtenir);

        }



        /// <summary>
        /// Permet d'attribuer un propriétaires à un documement.
        /// </summary>
        /// <example>
        /// <code>
        /// Document cocument = new Document();
        /// Document.AjouterProporiétaire(membre)
        /// 
        /// </code>
        /// </example>
        /// <param name="membre">Notre membre Concerné.</param>
        /// <param name="document">Le type de type l'évenement de notre événement .</param>
        public static void AjouterProporiétaire(this Document document,Membre membre )
        {
            var Obtenir = new Obtenir()
            {
                IdDocument = document.Id,
                IdMembre = membre.Id
            };
            DatabaseHelper.sqliteconnection.Insert(Obtenir);

        }

        /// <summary>
        /// Permet de réccupérer les documents attribués à un membre
        /// </summary>
        /// <example>
        /// <code>
        /// List<Document> document = membre.SesDocuments();
        ///  
        /// </code>
        /// </example>
        /// <param name="membre">Notre membre Concerné.</param>
       
        public static async Task<List<Document>> SesDocuments(this Membre membre)
        {
            var result = new List<Document>();
            foreach(var tmp in DatabaseHelper.sqliteconnection.Table<Obtenir>().Where(t => t.IdMembre == membre.Id).ToList())
            {
                result.Add( await tmp.GetDocument());
            }
            return result;
           

        }

     

        /// <summary>
        /// Permet de réccupérer les Membres liés à un document
        /// </summary>
        /// <example>
        /// <code>
        /// List<Membre> membres = document.SesProprietaires();
        ///  
        /// </code>
        /// </example>
        /// <param name="doc">Notre document concerné.</param>
        public static List<Membre> SesProprietaires(this Document doc)
        {
            var result = new List<Membre>();
            foreach (var tmp in DatabaseHelper.sqliteconnection.Table<Obtenir>().Where(t => t.IdDocument == doc.Id).ToList())
            {
                result.Add(tmp.GetMembre());
            }
            return result;

        }
        /// <summary>
        ///Supprimmer toutes les liaisons à un documment
        /// </summary>
        /// <example>
        /// <code>
        /// List<Membre> membres = document.SupprimerTouteProprieté();
        ///  
        /// </code>
        /// </example>
        /// <param name="doc">Notre document concerné.</param>
        public static void SupprimerTouteProprieté(this DatabaseHelper bd)
        {
            DatabaseHelper.sqliteconnection.DeleteAll<Obtenir>();
        }

        private static  async Task<Document> GetDocument(this Obtenir o)
        {
            return await new DatabaseHelper().DocumentByIdAsync(o.IdDocument);
          
        }

       


        private static Membre GetMembre(this Obtenir o)
        {
            return new DatabaseHelper().MembreById(o.IdMembre);
        }

        private static List<Obtenir> ListeObtenir(this DatabaseHelper bd)
        {
            return DatabaseHelper.sqliteconnection.Table<Obtenir>().ToList();

        }

    }
}
