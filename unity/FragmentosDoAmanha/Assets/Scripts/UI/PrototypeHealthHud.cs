using FragmentosDoAmanha.Player;
using UnityEngine;

namespace FragmentosDoAmanha.UI
{
    public sealed class PrototypeHealthHud : MonoBehaviour
    {
        [SerializeField] private PlayerHealth playerHealth;

        private int currentHealth;
        private int maxHealth;
        private GUIStyle labelStyle;
        private Texture2D fillTexture;
        private Texture2D emptyTexture;
        private Texture2D shadowTexture;

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
            labelStyle = new GUIStyle
            {
                fontSize = 22,
                fontStyle = FontStyle.Bold
            };
            labelStyle.normal.textColor = new Color(1f, 0.72f, 0.22f);
            fillTexture = CreateTexture(new Color(1f, 0.72f, 0.22f));
            emptyTexture = CreateTexture(new Color(0.18f, 0.13f, 0.08f));
            shadowTexture = CreateTexture(new Color(0f, 0f, 0f, 0.55f));
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
            if (labelStyle == null)
            {
                Awake();
            }

            GUI.Label(new Rect(24f, 18f, 48f, 32f), "HP", labelStyle);

            for (int i = 0; i < maxHealth; i++)
            {
                Rect shadowRect = new Rect(67f + (i * 25f), 25f, 20f, 16f);
                Rect pipRect = new Rect(65f + (i * 25f), 23f, 20f, 16f);
                GUI.DrawTexture(shadowRect, shadowTexture);
                GUI.DrawTexture(pipRect, i < currentHealth ? fillTexture : emptyTexture);
            }
        }

        private static Texture2D CreateTexture(Color color)
        {
            Texture2D texture = new Texture2D(1, 1);
            texture.SetPixel(0, 0, color);
            texture.Apply();
            return texture;
        }
    }
}
