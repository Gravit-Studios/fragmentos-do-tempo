using FragmentosDoAmanha.Player;
using UnityEngine;

namespace FragmentosDoAmanha.Systems
{
    [RequireComponent(typeof(Collider2D))]
    public sealed class PrototypeGoalZone : MonoBehaviour
    {
        [SerializeField] private PrototypeObjectiveState objectiveState;

        public void SetObjectiveState(PrototypeObjectiveState newObjectiveState)
        {
            objectiveState = newObjectiveState;
        }

        private void Awake()
        {
            Collider2D goalCollider = GetComponent<Collider2D>();
            goalCollider.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            FragmentInventory inventory = other.GetComponentInParent<FragmentInventory>();
            if (objectiveState == null || inventory == null)
            {
                return;
            }

            objectiveState.TryComplete(inventory);
        }
    }
}
