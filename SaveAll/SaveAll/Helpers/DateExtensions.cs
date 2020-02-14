using SaveAll.Model;
using SaveAll.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Xamarin.Forms.Maps;

namespace SaveAll.Helpers
{
    public static class DateExtensions
    {
        /// <summary>
        /// convertir la position du bien en position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static Position ToPosition(this string position)
        {
            try
            {
                var l = position.Split('/');
                return new Position(Convert.ToDouble(l[0]), Convert.ToDouble(l[1]));
            }

            catch (Exception e)
            {
                return new Position(0,0);
            }

        }


        /// <summary>
        /// convertir la position du bien en string
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static string ToStringPosition(this Position position)
        {
          
            return $"{position.Latitude}/{position.Longitude}";


        }


        /// <summary>
        /// prochaine date de l'evenement si reccurent
        /// </summary>
        /// <param name="date"></param>
        /// <param name="id"></param>
        /// <returns></returns>

        public static DateTime ProchaineDate(this DateTime date, int id)
        {
            switch (id)
            {
                case (int)Model.Enums.Periodicite.Journalier:
                    {
                        return date.AddDays(1);

                    }
                case (int)Model.Enums.Periodicite.Annuel:
                    {
                        return date.AddYears(1);
                        
                    }
                case (int)Model.Enums.Periodicite.Hebdomadaire:
                    {
                        return date.AddDays(7);
                       
                    }
                case (int)Model.Enums.Periodicite.Mensuel:
                    {
                        return date.AddMonths(1);
                      
                    }
                case (int)Model.Enums.Periodicite.BiMensuel:
                    {
                        return date.AddMonths(2);
                      
                    }
                case (int)Model.Enums.Periodicite.TriMestriel:
                    {
                        return date.AddMonths(3);
                       
                    }
                case (int)Model.Enums.Periodicite.Semestriel:
                    {
                        return date.AddMonths(6);
                       
                    }
                default: return DateTime.Now;
            }
        }

        /// <summary>
        /// Permet de Permet réccuperer la liste des Evénement d'une date.
        /// </summary>
        /// <example>
        /// <code>
        /// Evenement evenement = new Evenement();
        /// evenement.EvenementsByDate()
        /// 
        /// </code>
        /// </example>
        /// <param name="date">L date dont nous voulons les événements enregistrés.</param>
        public static List<Evenement> EvenementsByDate(this DateTime date)
        {
            return DatabaseHelper.sqliteconnection.Table<Evenement>().Where(p => p.ProchainEvenemt == date).ToList();

        }
        /// <summary>
        /// Permet de Permet réccuperer la liste des Evénement du jour.
        /// </summary>
        /// <example>
        /// <code>
        /// Evenement evenement = new Evenement();
        /// evenement.TodayEvents()
        /// 
        /// </code>
        /// </example>
       
        public static List<Evenement> TodayEvents()
        {
            return DatabaseHelper.sqliteconnection.Table<Evenement>().Where(p => p.ProchainEvenemt.Value.Date == DateTime.Today).ToList();

        }

        /// <summary>
        /// Fonction de cryptage md5 pour le mot de passe
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>

        public static string EncodeMd5(this string  pass)
        {
            string motDePasseSel = $"Encoder{pass}AUTHENT"; // au lieu de "" + "" +
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(motDePasseSel)));
        }

    }
}
