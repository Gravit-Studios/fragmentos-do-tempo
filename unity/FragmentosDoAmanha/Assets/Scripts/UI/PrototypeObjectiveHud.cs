using FragmentosDoAmanha.Systems;
using UnityEngine;

namespace FragmentosDoAmanha.UI
{
    public sealed class PrototypeObjectiveHud : MonoBehaviour
    {
        [SerializeField] private PrototypeObjectiveState objectiveState;

        private string message = "COLETE O FRAGMENTO TEMPORAL";
        private GUIStyle style;

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

            GUI.Label(new Rect(24f, 92f, 520f, 36f), message, style);
        }

        private void UpdateMessage()
        {
            if (objectiveState != null)
            {
                message = objectiveState.CurrentMessage;
            }
        }
    }
}
