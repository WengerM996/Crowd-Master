using UnityEngine;

public interface IDamageable
{
    bool ApplyDamage(Rigidbody rigidBody, float force);
}
