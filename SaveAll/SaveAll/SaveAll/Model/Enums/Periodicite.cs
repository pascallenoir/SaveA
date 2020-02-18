using System;
using System.Collections.Generic;
using System.Text;

namespace SaveAll.Model.Enums
{
    [Flags]
    public enum Periodicite
    {
        NonPeriodique=0,
        Journalier=1,
        Hebdomadaire=7,
        Quinzaine=15,
        Mensuel=30,
        BiMensuel=60,
        TriMestriel=90,
        Semestriel =180,
        Annuel = 365,
        Horaire
    }
}
