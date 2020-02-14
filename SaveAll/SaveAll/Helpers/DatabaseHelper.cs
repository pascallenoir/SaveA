using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaveAll.Model;
using Xamarin.Forms;
using SQLite;
using PCLExt.FileStorage.Folders;
using PCLExt.FileStorage;

namespace SaveAll.Helpers
{
    public class DatabaseHelper
    {
        

        public static SQLiteConnection sqliteconnection;
        public const string DbFileName = "SavallDatabase.db";

        /// <summary>
        /// Permet de retourner une connexion au fichier SQLite si le fichier n'existe pas il est crée
        /// </summary>
        /// <example>
        /// <code>
        /// var db = new DatabaseHelper()
        /// ;
        /// 
        /// </code>
        /// </example>
       
        public DatabaseHelper()
        {
            // crée un dossier personnel local pour le périphérique
            var paste = new LocalRootFolder();
            // crée le fichier
            var archve = paste.CreateFile(DbFileName, CreationCollisionOption.OpenIfExists);
            // open ou BD
            sqliteconnection = new SQLiteConnection(archve.Path);

            //sqliteconnection = DependencyService.Get<ISQLite>().GetConnection();
             InitAsync().Wait();
            
        }
        /// <summary>
        /// Permet de creer les tables de la base de données et d'y enregistrer les informations de base
        /// </summary>
        /// <example>
        /// <code>
        /// var db = new DatabaseHelper()
        /// ;
        /// 
        /// </code>
        /// </example>

        private async System.Threading.Tasks.Task InitAsync()
        {
           
            sqliteconnection.CreateTable<Membre>();
            sqliteconnection.CreateTable<Document>();
            sqliteconnection.CreateTable<Evenement>();
            sqliteconnection.CreateTable<Patrimoine>();

            sqliteconnection.CreateTable<TypeDocument>();
            var typesdoc = await this.TousLesTypesDocumentsAsync();
            if (typesdoc.Count == 0)
                sqliteconnection.InsertAll(Constants.TypeDocuments());

            sqliteconnection.CreateTable<TypeMembre>();
            var typesmem = await this.TousLesTypesMembres();
            if (typesmem.Count == 0)
                sqliteconnection.InsertAll(Constants.TypeMembres());


            sqliteconnection.CreateTable<TypePatrimoine>();
            var typespatri = await this.TousLesTypesPatrimoines();
            if (typespatri.Count == 0)
                sqliteconnection.InsertAll(Constants.TypePatrimoines());


            sqliteconnection.CreateTable<Periodicite>();
            var per = await this.TousLesTypesPeriodicitesAsync();
            if (per.Count == 0)
            sqliteconnection.InsertAll(Constants.periodicites());

            sqliteconnection.CreateTable<TypeEvenement>();


            var ev = await this.TousLesTypesEvenementsAsync();
            if (ev.Count == 0)
            sqliteconnection.InsertAll(Constants.TypeEvenements());

            sqliteconnection.CreateTable<ObtenirBien>();
            sqliteconnection.CreateTable<Programmer>();
            sqliteconnection.CreateTable<Obtenir>();
        }
        

    }
}
