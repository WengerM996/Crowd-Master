using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IDamageable
{
    public bool ApplyDamage(Rigidbody rigidBody, float force)
    {
        print("box");
        return true;
    }
}
