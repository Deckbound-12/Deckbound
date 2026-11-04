using UnityEngine;

namespace DeckBound.Combat
{
    // Porneste animatia de atac a eroului la fiecare carte jucata
    // si il misca putin spre inamic, apoi inapoi.
    [RequireComponent(typeof(Animator))]
    public class CardPlayAnimator : MonoBehaviour
    {
        private static readonly int AttackState = Animator.StringToHash("Attack");

        // Partea din miscare in care eroul inainteaza; restul e intoarcerea.
        private const float ForwardPortion = 0.4f;

        [SerializeField] private CombatManager combat;

        [Header("Miscare spre inamic")]
        [SerializeField, Min(0f)] private float lungeDistance = 0.5f;
        [Tooltip("Durata totala, dus-intors. Implicit e cat animatia de atac.")]
        [SerializeField, Min(0.01f)] private float lungeDuration = 0.5f;

        private Animator animator;
        private Vector3 restPosition;
        private float direction = 1f;
        private float offset;
        private float startOffset;
        private float elapsed;
        private bool lunging;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            restPosition = transform.position;
        }

        private void OnEnable()
        {
            if (combat != null) combat.OnCardPlayed += HandleCardPlayed;
        }

        private void OnDisable()
        {
            if (combat != null) combat.OnCardPlayed -= HandleCardPlayed;

            lunging = false;
            offset = 0f;
            transform.position = restPosition;
        }

        private void Update()
        {
            if (lunging) AdvanceLunge(Time.deltaTime);
        }

        // Porneste de la inceput, ca o carte jucata imediat dupa alta sa aiba animatia ei.
        private void HandleCardPlayed(Card card)
        {
            animator.Play(AttackState, 0, 0f);

            direction = Mathf.Sign(combat.Enemy.transform.position.x - restPosition.x);
            startOffset = offset; // continua din pozitia curenta, fara salt
            elapsed = 0f;
            lunging = true;
        }

        private void AdvanceLunge(float deltaTime)
        {
            elapsed += deltaTime;
            float t = elapsed / lungeDuration;

            if (t >= 1f)
            {
                offset = 0f;
                lunging = false;
            }
            else if (t < ForwardPortion)
            {
                offset = Mathf.SmoothStep(startOffset, lungeDistance, t / ForwardPortion);
            }
            else
            {
                offset = Mathf.SmoothStep(lungeDistance, 0f, (t - ForwardPortion) / (1f - ForwardPortion));
            }

            transform.position = restPosition + Vector3.right * (direction * offset);
        }
    }
}
