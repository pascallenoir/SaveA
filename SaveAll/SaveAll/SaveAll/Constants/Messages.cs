using System;
using System.Collections.Generic;
using System.Text;

namespace SaveAll
{
    public static class Messages
    {
        public static string MessageNonNull { get; private set; } = "Le champs suivant ne peut etre vide";

        public static string MessageTitle { get; private set; } = "Felicitation";
        public static string MessageEnregistrement { get; private set; } = "Enregistrement";
        public static string MessageSuppression{ get; private set; } = "Suppression";


        public static string MessageTitleVerification { get; private set; } = "Verification";
        public static string MessageVerificationReponse { get; private set; } = "la reponse saisie a été vérifiée, vous pouvez passer a l'étape suivante";
        public static string MessageVerificationReponseIncorrecte { get; private set; } = "la reponse saisie n'est pas correcte. Entrer une reponse valide ou quitter la procedure";


        public static string MessageVerificationUsername{ get; private set; } = "le nom d'utilisateur saisi a été vérifiée, vous pouvez passer a l'étape suivante";
        public static string MessageVerificationUsernameIncorrecte { get; private set; } = "le nom d'utilisateur saisi n'est pas correcte. Entrer un Login valide ou quitter la procedure";

        public static string MessageAlerteSuppresionTotal { get; private set; } = "Vous etes sur le point de supprimer toutes les informations de votre liste de document";

        public static string MessageAlerteSuppresionelement { get; private set; } = "Vous souhaitez vraiment supprimer cet element ?";
        public static string MessageSucces { get; private set; } = "Terminé";
        public static string MessageOk { get; private set; } = "Informations enregistrées avec succes !";
        public static string MessageOkSuppression { get; private set; } = "Informations supprimees avec succes !";

        public static string MessageTitleValidator { get; private set; } = "Desole";

        public static string MessageTitleError { get; private set; } = "Identification";
        public static string MessageValidation { get; private set; } = "Souhaitez-vous enregistrer ces informations ?";

        public static string Messageloginfail { get; private set; } = "le nom d'utilisateur ou le mot de passe n'existe pas ";

        public static string MessagePassword { get; private set; } = "Votre mot de passe doit contenir au moins 4 caracteres ";

        public static string Messagedontmatch { get; private set; } = "Desole, mais les mots de passes ne correspondent pas. Reessayez s'il vous plait ";

        public static string MessageAlerteInscription { get; private set; } = "Vous etes bien inscrit ! Veiller a memoriser vos informations pour votre prochaine connexion.";

        public static string MessageAlerteReinitialisation { get; private set; } = "Votre mot de passe a ete reinitialise avec succes. Connectez- vous desormais avec ce nouveau mot de passe.";
        public static string MessageAlerteMiseAJour { get; private set; } = "Informations mise a jour avec succes !";


    }
}
