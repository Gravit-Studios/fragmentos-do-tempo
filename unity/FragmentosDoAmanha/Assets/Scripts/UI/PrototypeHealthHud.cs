using FragmentosDoAmanha.Player;
using UnityEngine;

namespace FragmentosDoAmanha.UI
{
    public sealed class PrototypeHealthHud : MonoBehaviour
    {
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private string filledPip = "#";
        [SerializeField] private string emptyPip = "-";

        private int currentHealth;
        private int maxHealth;
        private GUIStyle style;

        public void SetPlayerHealth(PlayerHealth newPlayerHealth)
        {
            if (playerHealth != null)
            {
                playerHealth.HealthChanged -= UpdateHealth;
            }

            playerHealth = newPlayerHealth;

            if (playerHealth != null)
            {
                playerHealth.HealthChanged += UpdateHealth;
                UpdateHealth(playerHealth.CurrentHealth, playerHealth.MaxHealth);
            }
        }

        private void Awake()
        {
            style = new GUIStyle
            {
                fontSize = 28,
                fontStyle = FontStyle.Bold
            };
            style.normal.textColor = new Color(1f, 0.72f, 0.22f);
        }

        private void OnEnable()
        {
            if (playerHealth != null)
            {
                playerHealth.HealthChanged += UpdateHealth;
                UpdateHealth(playerHealth.CurrentHealth, playerHealth.MaxHealth);
            }
        }

        private void OnDisable()
        {
            if (playerHealth != null)
            {
                playerHealth.HealthChanged -= UpdateHealth;
            }
        }

        private void UpdateHealth(int currentHealth, int maxHealth)
        {
            this.currentHealth = currentHealth;
            this.maxHealth = maxHealth;
        }

        private void OnGUI()
        {
            if (style == null)
            {
                Awake();
            }

            GUI.Label(new Rect(24f, 20f, 240f, 48f), $"HP {BuildPips(currentHealth, maxHealth)}", style);
        }

        private string BuildPips(int currentHealth, int maxHealth)
        {
            string pips = string.Empty;
            for (int i = 0; i < maxHealth; i++)
            {
                pips += i < currentHealth ? filledPip : emptyPip;
            }

            return pips;
        }
    }
}
