using DeckBound.Combat;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DeckBound.UI
{
    // O optiune de pe ecranul de selectie: la click alege eroul si porneste lupta.
    [RequireComponent(typeof(Button))]
    public class HeroSelectOption : MonoBehaviour
    {
        [SerializeField] private HeroData hero;
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private string combatScene = "SampleScene";

        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
            if (nameText != null && hero != null) nameText.text = hero.displayName;
        }

        private void OnEnable()
        {
            button.onClick.AddListener(Select);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(Select);
        }

        private void Select()
        {
            HeroSelection.Selected = hero;
            SceneManager.LoadScene(combatScene);
        }
    }
}
