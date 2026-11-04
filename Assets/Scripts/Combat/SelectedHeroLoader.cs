using UnityEngine;

namespace DeckBound.Combat
{
    // Aplica eroul ales pe obiectul Hero din lupta. Fara selectie ramane eroul din scena.
    [RequireComponent(typeof(Combatant), typeof(Animator))]
    public class SelectedHeroLoader : MonoBehaviour
    {
        private void Awake()
        {
            var hero = HeroSelection.Selected;
            if (hero == null) return;

            GetComponent<Combatant>().SetDisplayName(hero.displayName);
            GetComponent<Animator>().runtimeAnimatorController = hero.animatorController;
        }
    }
}
