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
        [SerializeField] private float minimumTransitionDisplayDuration = 0.85f;
        [SerializeField] private string transitionMessage = "RUPTURA TEMPORAL";

        private bool isLoading;
        private float loadTimer;
        private GUIStyle messageStyle;
        private GUIStyle shadowStyle;

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
            loadTimer = Mathf.Max(loadDelay, minimumTransitionDisplayDuration);
        }

        private void OnGUI()
        {
            if (!isLoading)
            {
                return;
            }

            EnsureStyles();

            float pulse = Mathf.PingPong(Time.unscaledTime * 8f, 1f);
            messageStyle.normal.textColor = Color.Lerp(new Color(0.25f, 0.95f, 1f), Color.white, pulse);

            Rect shadowRect = new Rect(0f, Screen.height * 0.42f + 3f, Screen.width, 48f);
            Rect messageRect = new Rect(0f, Screen.height * 0.42f, Screen.width, 48f);
            GUI.Label(shadowRect, transitionMessage, shadowStyle);
            GUI.Label(messageRect, transitionMessage, messageStyle);
        }

        private void EnsureStyles()
        {
            if (messageStyle != null)
            {
                return;
            }

            messageStyle = new GUIStyle
            {
                alignment = TextAnchor.MiddleCenter,
                fontSize = 28,
                fontStyle = FontStyle.Bold
            };
            messageStyle.normal.textColor = new Color(0.25f, 0.95f, 1f);

            shadowStyle = new GUIStyle(messageStyle);
            shadowStyle.normal.textColor = new Color(0f, 0f, 0f, 0.75f);
        }
    }
}
