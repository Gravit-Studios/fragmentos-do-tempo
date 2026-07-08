using FragmentosDoAmanha.Player;
using UnityEngine;

namespace FragmentosDoAmanha.UI
{
    public sealed class PrototypeFragmentHud : MonoBehaviour
    {
        [SerializeField] private FragmentInventory inventory;

        private int fragmentCount;
        private GUIStyle style;

        public void SetInventory(FragmentInventory newInventory)
        {
            if (inventory != null)
            {
                inventory.FragmentCountChanged -= UpdateFragments;
            }

            inventory = newInventory;

            if (inventory != null)
            {
                inventory.FragmentCountChanged += UpdateFragments;
                UpdateFragments(inventory.FragmentCount);
            }
        }

        private void Awake()
        {
            style = new GUIStyle
            {
                fontSize = 22,
                fontStyle = FontStyle.Bold
            };
            style.normal.textColor = new Color(0.35f, 0.9f, 1f);
        }

        private void OnEnable()
        {
            if (inventory != null)
            {
                inventory.FragmentCountChanged += UpdateFragments;
                UpdateFragments(inventory.FragmentCount);
            }
        }

        private void OnDisable()
        {
            if (inventory != null)
            {
                inventory.FragmentCountChanged -= UpdateFragments;
            }
        }

        private void OnGUI()
        {
            if (style == null)
            {
                Awake();
            }

            GUI.Label(new Rect(24f, 54f, 260f, 40f), $"FRAG {fragmentCount}/1", style);
        }

        private void UpdateFragments(int newFragmentCount)
        {
            fragmentCount = newFragmentCount;
        }
    }
}
