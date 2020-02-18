using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaveAll.Model;

namespace SaveAll.Helpers
{
   public static class GenericExtensions
    {
        /// <summary>
        /// Fermet d'éffectuer une mise à jour sur les données de données
        /// </summary>
        /// <example>
        /// <code>
        /// Object o = new Object();
        /// Evenement evenement = DatabaseHelper().MisAjour(o);
        ///
        /// 
        /// </code>
        /// </example>
        /// <param name="o">L'objet existant en base</param>
        public static void MisAjourEnBase(this Object o)
        {
            DatabaseHelper.sqliteconnection.Update(o);
        }
        /// <summary>
        /// Fermet d'éffectuer un Enregistrement dans la base de donnée ou d'ignorer si lavaleur n'est pas valide
        /// </summary>
        /// <example>
        /// <code>
        /// Object o = new Object();
        /// o.EnregistrerEnBase();
        ///
        /// 
        /// </code>
        /// </example>
        /// <param name="o">Nouvel objet à enregistrer</param>
        public static void EnregistrerEnBase(this object o)
        {
            if (o.GetType() == typeof(Membre))
            {
                var newMember = o as Membre;
                var membres =  new DatabaseHelper().ListeMembreAsync();
                newMember.Principal = !membres.GetAwaiter().GetResult().Any(p=>p.Principal);
                DatabaseHelper.sqliteconnection.Insert(newMember);
            }
            else
            {
                DatabaseHelper.sqliteconnection.Insert(o);
            }
           
        }
    }
}
