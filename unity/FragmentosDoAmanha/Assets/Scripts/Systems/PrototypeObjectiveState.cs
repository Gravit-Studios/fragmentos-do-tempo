using System;
using FragmentosDoAmanha.Player;
using UnityEngine;

namespace FragmentosDoAmanha.Systems
{
    public sealed class PrototypeObjectiveState : MonoBehaviour
    {
        [SerializeField] private int requiredFragments = 1;
        [SerializeField] private FragmentInventory inventory;

        private bool isComplete;

        public bool IsComplete => isComplete;
        public int RequiredFragments => requiredFragments;
        public int CurrentFragments => inventory != null ? inventory.FragmentCount : 0;
        public string CurrentMessage => BuildMessage();

        public event Action ObjectiveChanged;

        public void SetInventory(FragmentInventory newInventory)
        {
            if (inventory != null)
            {
                inventory.FragmentCountChanged -= HandleFragmentCountChanged;
            }

            inventory = newInventory;

            if (inventory != null)
            {
                inventory.FragmentCountChanged += HandleFragmentCountChanged;
            }

            ObjectiveChanged?.Invoke();
        }

        public bool TryComplete(FragmentInventory playerInventory)
        {
            if (isComplete || playerInventory == null || playerInventory.FragmentCount < requiredFragments)
            {
                return false;
            }

            isComplete = true;
            ObjectiveChanged?.Invoke();
            return true;
        }

        private void OnDisable()
        {
            if (inventory != null)
            {
                inventory.FragmentCountChanged -= HandleFragmentCountChanged;
            }
        }

        private void HandleFragmentCountChanged(int _)
        {
            ObjectiveChanged?.Invoke();
        }

        private string BuildMessage()
        {
            if (isComplete)
            {
                return "OBJETIVO CONCLUIDO";
            }

            if (CurrentFragments >= requiredFragments)
            {
                return "LEVE O FRAGMENTO AO MARCADOR FINAL";
            }

            return "COLETE O FRAGMENTO TEMPORAL";
        }
    }
}
