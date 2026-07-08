using FragmentosDoAmanha.Systems;
using UnityEngine;

namespace FragmentosDoAmanha.UI
{
    public sealed class PrototypeObjectiveHud : MonoBehaviour
    {
        [SerializeField] private PrototypeObjectiveState objectiveState;
        [SerializeField] private float feedbackDuration = 1.1f;

        private string message = "COLETE O FRAGMENTO TEMPORAL";
        private float feedbackTimer;
        private GUIStyle style;
        private GUIStyle shadowStyle;

        public void SetObjectiveState(PrototypeObjectiveState newObjectiveState)
        {
            if (objectiveState != null)
            {
                objectiveState.ObjectiveChanged -= UpdateMessage;
            }

            objectiveState = newObjectiveState;

            if (objectiveState != null)
            {
                objectiveState.ObjectiveChanged += UpdateMessage;
                UpdateMessage();
            }
        }

        private void Awake()
        {
            style = new GUIStyle
            {
                fontSize = 18,
                fontStyle = FontStyle.Bold
            };
            style.normal.textColor = Color.white;

            shadowStyle = new GUIStyle(style);
            shadowStyle.normal.textColor = new Color(0f, 0f, 0f, 0.65f);
        }

        private void OnEnable()
        {
            if (objectiveState != null)
            {
                objectiveState.ObjectiveChanged += UpdateMessage;
                UpdateMessage();
            }
        }

        private void OnDisable()
        {
            if (objectiveState != null)
            {
                objectiveState.ObjectiveChanged -= UpdateMessage;
            }
        }

        private void OnGUI()
        {
            if (style == null)
            {
                Awake();
            }

            float pulse = feedbackTimer > 0f ? Mathf.PingPong(Time.unscaledTime * 8f, 1f) : 0f;
            int baseFontSize = objectiveState != null && objectiveState.IsComplete ? 22 : 18;
            style.fontSize = baseFontSize + Mathf.RoundToInt(pulse * 4f);
            shadowStyle.fontSize = style.fontSize;
            style.normal.textColor = GetMessageColor(pulse);

            Rect shadowRect = new Rect(26f, 94f, 560f, 40f);
            Rect textRect = new Rect(24f, 92f, 560f, 40f);
            GUI.Label(shadowRect, message, shadowStyle);
            GUI.Label(textRect, message, style);

            if (feedbackTimer > 0f)
            {
                feedbackTimer = Mathf.Max(0f, feedbackTimer - Time.unscaledDeltaTime);
            }
        }

        private void UpdateMessage()
        {
            if (objectiveState != null)
            {
                string previousMessage = message;
                message = objectiveState.CurrentMessage;
                if (message != previousMessage)
                {
                    feedbackTimer = feedbackDuration;
                }
            }
        }

        private Color GetMessageColor(float pulse)
        {
            if (objectiveState != null && objectiveState.IsComplete)
            {
                return Color.Lerp(new Color(0.45f, 1f, 0.45f), Color.white, pulse);
            }

            if (objectiveState != null && objectiveState.CurrentFragments >= objectiveState.RequiredFragments)
            {
                return Color.Lerp(new Color(0.35f, 0.9f, 1f), Color.white, pulse);
            }

            return Color.Lerp(Color.white, new Color(0.35f, 0.9f, 1f), pulse);
        }
    }
}
