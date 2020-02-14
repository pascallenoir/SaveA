using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaveAll.Model;

namespace SaveAll.Helpers
{
    public static class TypePeriodiciteExtensions
    {
       
        
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
            /// 
            public static async Task<List<Periodicite>> TousLesTypesPeriodicitesAsync(this DatabaseHelper bd)
            {
            return DatabaseHelper.sqliteconnection.Table<Periodicite>().AsParallel().ToList();

            }
           

           
        
    }
}
