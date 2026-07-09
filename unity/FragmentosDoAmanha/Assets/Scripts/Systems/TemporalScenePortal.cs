using FragmentosDoAmanha.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FragmentosDoAmanha.Systems
{
    [RequireComponent(typeof(Collider2D))]
    public sealed class TemporalScenePortal : MonoBehaviour
    {
        [SerializeField] private PrototypeObjectiveState objectiveState;
        [SerializeField] private string targetSceneName = "VS_Egypt_Blockout";
        [SerializeField] private bool requireCompletedObjective = true;
        [SerializeField] private float loadDelay = 0.35f;

        private bool isLoading;
        private float loadTimer;

        public void SetObjectiveState(PrototypeObjectiveState newObjectiveState)
        {
            objectiveState = newObjectiveState;
        }

        public void SetTargetScene(string newTargetSceneName)
        {
            targetSceneName = newTargetSceneName;
        }

        public void SetRequireCompletedObjective(bool shouldRequireCompletedObjective)
        {
            requireCompletedObjective = shouldRequireCompletedObjective;
        }

        private void Awake()
        {
            Collider2D portalCollider = GetComponent<Collider2D>();
            portalCollider.isTrigger = true;
        }

        private void Update()
        {
            if (!isLoading)
            {
                return;
            }

            loadTimer -= Time.deltaTime;
            if (loadTimer <= 0f)
            {
                SceneManager.LoadScene(targetSceneName);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (isLoading || string.IsNullOrWhiteSpace(targetSceneName))
            {
                return;
            }

            FragmentInventory inventory = other.GetComponentInParent<FragmentInventory>();
            if (inventory == null)
            {
                return;
            }

            if (objectiveState != null && !objectiveState.IsComplete)
            {
                objectiveState.TryComplete(inventory);
            }

            if (requireCompletedObjective && (objectiveState == null || !objectiveState.IsComplete))
            {
                return;
            }

            isLoading = true;
            loadTimer = loadDelay;
        }
    }
}
