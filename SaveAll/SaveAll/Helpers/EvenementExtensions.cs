using System;
using System.Collections.Generic;
using System.Text;
using SaveAll.Model;
using SaveAll.Model.Enums;
using SaveAll.Helpers;
using System.Linq;

namespace SaveAll.Helpers
{
    public static class EvenementExtensions
    {


        /// <summary>
        /// Permet de lier un evenement à son type.
        /// </summary>
        /// <example>
        /// <code>
        /// Evenement evenement = new Evenement();
        /// evenement.AffecterTypeEvenement(typeEvenement)
        /// 
        /// </code>
        /// </example>
        /// <param name="evenement">Notre événement Concerné.</param>
        /// <param name="typeEvenement">Le type de type l'évenement de notre événement .</param>

        public static void AffecterTypeEvenement(this Evenement evenement, TypeEvenement typeEvenement)
        {
            evenement.ProchainEvenemt = evenement.DateDeb.ProchaineDate(typeEvenement.IDPeriodicite);
            evenement.dateDerModif = DateTime.Now;
            evenement.idTypeEv = typeEvenement.IdTypeEvenement;

        }

        /// <summary>
        /// Permet de Permet de dire traiter un événement.
        /// </summary>
        /// <example>
        /// <code>
        /// Evenement evenement = new Evenement();
        /// evenement.TraiterUnEvenement()
        /// 
        /// </code>
        /// </example>
        /// <param name="evenement">Notre événement Concerné.</param>


        public static async void TraiterUnEvenement(this Evenement evenement)
        {
            evenement.Traite = 0 == 0;
            var typeEvenement = await evenement.SonTypeEvenementAsync();
             evenement.ProchainEvenemt = evenement.DateDeb.ProchaineDate(typeEvenement.IDPeriodicite);
            evenement.MisAjourEnBase();
        }
       

        /// <summary>
        /// Permet de Permet réccuperer la liste des Evénement enrégistrés dans la base de données.
        /// </summary>
        /// <example>
        /// <code>
        ///
        /// new DatabaseHelper().TousLesEvenements()
        /// 
        /// </code>
        /// </example>


        public static List<Evenement> TousLesEvenements(this DatabaseHelper bd)
        {

            return  DatabaseHelper.sqliteconnection.Table<Evenement>().ToList();
        }
        /// <summary>
        /// Permet de Permet réccuperer un événement connsaissant son ID.
        /// </summary>
        /// <example>
        /// <code>
        /// 
        /// Evenement evenement = DatabaseHelper().EvenementById(ID);
        ///
        /// 
        /// </code>
        /// </example>
        /// <param name="Id">l'identifiant de l'évenement que nous voulons réccuperer parmis les événements enregistrés.</param>
        public static Evenement EvenementById(this DatabaseHelper bd, int Id)
        {
            return DatabaseHelper.sqliteconnection.Table<Evenement>().FirstOrDefault(t => t.id == Id);
            
        }
        /// <summary>
        /// Permet de Permet supprimer tous les événements dans la base de données.
        /// </summary>
        /// <example>
        /// <code>
        /// 
        /// Evenement evenement = DatabaseHelper().SupprimerTousLesEvenements();
        ///
        /// 
        /// </code>
        /// </example>
        /// <param name="bd">Notre Database Helper</param>
        public static void SupprimerTousLesEvenements(this DatabaseHelper bd)
        {
            DatabaseHelper.sqliteconnection.DeleteAll<Evenement>();
        }
        /// <summary>
        /// Permet de Permet supprimer un événement dans la base de données.
        /// </summary>
        /// <example>
        /// <code>
        /// 
        /// Evenement evenement = DatabaseHelper().SupprimerEvenement(Id);
        ///
        /// 
        /// </code>
        /// </example>
        /// <param name="Id">Identifiant de l'événement à supprimer</param>
        public static void SupprimerEvenement(this DatabaseHelper bd, int Id)
        {
            DatabaseHelper.sqliteconnection.Delete<Evenement>(Id);
        }


        

    }
}
