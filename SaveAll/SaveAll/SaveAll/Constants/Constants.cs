using System;
using System.Collections.Generic;
using System.Text;
using SaveAll.Model;
using SaveAll.Model.Enums;

namespace SaveAll
{
   public static class Constants
    {
     
        public static List<Model.Periodicite> periodicites()
        {

            return new List<Model.Periodicite>()
            {
                
                new Model.Periodicite(Model.Enums.Periodicite.Annuel
                ),
                new Model.Periodicite(Model.Enums.Periodicite.BiMensuel
                ),
                 new Model.Periodicite(Model.Enums.Periodicite.Hebdomadaire
                ),
                  new Model.Periodicite(Model.Enums.Periodicite.Horaire
                ),
                   new Model.Periodicite(
                       Model.Enums.Periodicite.Journalier
                ),
                  new Model.Periodicite(Model.Enums.Periodicite.Mensuel
                ),
                new Model.Periodicite(Model.Enums.Periodicite.NonPeriodique
                ),
                 new Model.Periodicite(Model.Enums.Periodicite.Quinzaine
                ),
                  new Model.Periodicite(Model.Enums.Periodicite.Semestriel
                ),
                new Model.Periodicite(Model.Enums.Periodicite.TriMestriel
                )
            };
         }

        public static List<TypeEvenement> TypeEvenements()
        {
            return new List<TypeEvenement>()
            {
                 new TypeEvenement()
                {
                    Nom = "Aucune Recurrence",
                     IDPeriodicite = (int)Model.Enums.Periodicite.NonPeriodique
                },
                new TypeEvenement()
                {
                    Nom= "Anniversaire",
                    IDPeriodicite= (int)Model.Enums.Periodicite.Annuel
                },
                new TypeEvenement()
                {
                    Nom = "Rendez-vous",
                    IDPeriodicite = (int)Model.Enums.Periodicite.NonPeriodique
                },
                 new TypeEvenement()
                {
                    Nom = "Redevance Mensuel",
                            IDPeriodicite = (int)Model.Enums.Periodicite.Mensuel
                },
                  new TypeEvenement()
                {
                    Nom = "Redevance à Terme",
                     IDPeriodicite = (int)Model.Enums.Periodicite.NonPeriodique
                }

            };
            
        }


        public static List<TypeDocument> TypeDocuments()
        {
            return new List<TypeDocument>(){
            new TypeDocument()
            {
                NomTypeDocument = "Passeport"
            },
            new TypeDocument()
            {
                NomTypeDocument = "Acte de Naisssance"
            },
            new TypeDocument()
            {
                NomTypeDocument = "Carnet de Santé"
            },
            new TypeDocument()
            {
                NomTypeDocument = "Visas"
            },
            new TypeDocument()
            {
                NomTypeDocument = "Permis de Conduire"
            },
            new TypeDocument()
            {
                NomTypeDocument = "Carte de séjour"
            },
            new TypeDocument()
            {
                NomTypeDocument = "Ordonnance médicale"
            },
            new TypeDocument()
            {
                NomTypeDocument = "Casier Judiciaire"
            },
            new TypeDocument()
            {
                NomTypeDocument = "Bulletin de Note"
            },
            new TypeDocument()
            {
                NomTypeDocument = "Ordre de Mission"
            },
            new TypeDocument()
            {
                NomTypeDocument = "Bulletin de Paie"
            },
            new TypeDocument()
            {
                NomTypeDocument = "Acte de Mariage"
            },
            new TypeDocument()
            {
                NomTypeDocument = "Testament"
            },
            new TypeDocument()
            {
                NomTypeDocument = "Contrat"
            },
            new TypeDocument()
            {
                NomTypeDocument = "Engagement"
            },
            new TypeDocument()
            {
                NomTypeDocument = "Titre Foncier"
            }

        };
        }


        public static List<TypePatrimoine> TypePatrimoines()
        {
            return new List<TypePatrimoine>(){
            new TypePatrimoine()
            {
                NomTypePatrimoine = "Bijoux"
            },
            new TypePatrimoine()
            {
                NomTypePatrimoine = "Vehicule"
            },
            new TypePatrimoine()
            {
                NomTypePatrimoine = "Maison"
            },
            new TypePatrimoine()
            {
                NomTypePatrimoine = "Terrain"
            },
            new TypePatrimoine()
            {
                NomTypePatrimoine = "Immeuble"
            },
            new TypePatrimoine()
            {
                NomTypePatrimoine = "Jet"
            },
            new TypePatrimoine()
            {
                NomTypePatrimoine = "Yatch"
            },
            new TypePatrimoine()
            {
                NomTypePatrimoine = "Foret"
            },
            new TypePatrimoine()
            {
                NomTypePatrimoine = "Entreprise"
            },
            new TypePatrimoine()
            {
                NomTypePatrimoine = "Compagnie"
            },
            new TypePatrimoine()
            {
                NomTypePatrimoine = "Plantation"
            }
          
        };
        }


        public static List<TypeMembre> TypeMembres()
        {
            return new List<TypeMembre>(){
            new TypeMembre()
            {
                NomTypeMembre = "Epouse"
            },
            new TypeMembre()
            {
                NomTypeMembre = "Epoux"
            },
            new TypeMembre()
            {
                NomTypeMembre = "Enfant"
            },
            new TypeMembre()
            {
                NomTypeMembre = "Petit enfant"
            },
            new TypeMembre()
            {
                NomTypeMembre = "Frere"
            },
            new TypeMembre()
            {
                NomTypeMembre = "Soeur"
            },
            new TypeMembre()
            {
                NomTypeMembre = "Pere"
            },
            new TypeMembre()
            {
                NomTypeMembre = "Mere"
            },
            new TypeMembre()
            {
                NomTypeMembre = "Oncle"
            },
            new TypeMembre()
            {
                NomTypeMembre = "Tante"
            },
            new TypeMembre()
            {
                NomTypeMembre = "Cousin"
            },
            new TypeMembre()
            {
                NomTypeMembre = "Cousine"
            },
            new TypeMembre()
            {
                NomTypeMembre = "Neveu"
            },
            new TypeMembre()
            {
                NomTypeMembre = "Niece"
            },
            new TypeMembre()
            {
                NomTypeMembre = "Belle-soeur"
            },
            new TypeMembre()
            {
                NomTypeMembre = "Beau-frere"
            },
            new TypeMembre()
            {
                NomTypeMembre = "Gendre"
            }

        };
        }

        

    }
}
