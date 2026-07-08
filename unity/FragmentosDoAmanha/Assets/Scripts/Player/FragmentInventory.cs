using System;
using UnityEngine;

namespace FragmentosDoAmanha.Player
{
    public sealed class FragmentInventory : MonoBehaviour
    {
        private int fragmentCount;

        public int FragmentCount => fragmentCount;

        public event Action<int> FragmentCountChanged;

        private void Start()
        {
            FragmentCountChanged?.Invoke(fragmentCount);
        }

        public void AddFragment(int amount)
        {
            if (amount <= 0)
            {
                return;
            }

            fragmentCount += amount;
            FragmentCountChanged?.Invoke(fragmentCount);
        }
    }
}
