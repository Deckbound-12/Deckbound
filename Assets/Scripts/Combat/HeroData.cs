using UnityEngine;

namespace DeckBound.Combat
{
    // Un erou care poate fi ales. Creezi unul din meniu: Create > DeckBound > Hero.
    [CreateAssetMenu(fileName = "NewHero", menuName = "DeckBound/Hero")]
    public class HeroData : ScriptableObject
    {
        public string displayName = "Hero";
        [Tooltip("Trebuie sa aiba starile Idle si Attack.")]
        public RuntimeAnimatorController animatorController;
    }
}
