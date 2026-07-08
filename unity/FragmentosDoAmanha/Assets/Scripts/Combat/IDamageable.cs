using UnityEngine;

namespace FragmentosDoAmanha.Combat
{
    public interface IDamageable
    {
        void TakeHit(int damage, Vector2 sourcePosition);
    }
}
