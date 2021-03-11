using UnityEngine;
using UnityEngine.Events;

public abstract class Ability : ScriptableObject
{
    protected Rigidbody Rigidbody;

    public abstract event UnityAction AttackEnded;

    public void Init(Rigidbody rigidBody)
    {
        Rigidbody = rigidBody;
    }

    public abstract void UseAbility(AttackState attack);
}
