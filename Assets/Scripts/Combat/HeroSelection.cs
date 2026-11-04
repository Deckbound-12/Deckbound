using UnityEngine;

namespace DeckBound.Combat
{
    // Eroul ales pe ecranul de selectie, pastrat cand se incarca scena de lupta.
    public static class HeroSelection
    {
        public static HeroData Selected { get; set; }

        // Proiectul nu reincarca domeniul la Play, deci alegerea trebuie stearsa manual.
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Reset()
        {
            Selected = null;
        }
    }
}
