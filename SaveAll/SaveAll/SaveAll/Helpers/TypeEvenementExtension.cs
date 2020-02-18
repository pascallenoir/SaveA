using SaveAll.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveAll.Helpers
{
    public static class TypeEvenementExtension
    {
     
        /// <summary>
        /// Afficher la liste de tous types evenements
        /// </summary>
        /// <param name="bd"></param>
        /// <returns></returns>
        public static async Task<List<TypeEvenement>> TousLesTypesEvenementsAsync(this DatabaseHelper bd)
        {
             return DatabaseHelper.sqliteconnection.Table<TypeEvenement>().AsParallel().ToList();
           
        }
        /// <summary>
        /// Permet de Permet réccuperer un type événement connsaissant son ID.
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
        public static async Task<TypeEvenement> TypeEvenementByIdAsync(this DatabaseHelper bd, int Id)
        {
            return DatabaseHelper.sqliteconnection.Table<TypeEvenement>().AsParallel().FirstOrDefault(t => t.IdTypeEvenement == Id);
            
        }

        /// <summary>
        /// Permet de Permet supprimer tous les type d'événements dans la base de données.
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
        public static void SupprimerTousLesTypesTypesEvenements(this DatabaseHelper bd)
        {
            DatabaseHelper.sqliteconnection.DeleteAll<TypeEvenement>();
        }


        /// <summary>
        /// supprimer un type evenement par son id
        /// </summary>
        /// <param name="bd"></param>
        /// <param name="Id"></param>
        public static void SupprimerTypeTypesEvenement(this DatabaseHelper bd, int Id)
        {
            DatabaseHelper.sqliteconnection.Delete<TypeEvenement>(Id);
        }


        public static async Task<TypeEvenement> SonTypeEvenementAsync(this Evenement evenement)
        {
            return  await new  DatabaseHelper().TypeEvenementByIdAsync((int)evenement.idTypeEv);
        }

    }
}
