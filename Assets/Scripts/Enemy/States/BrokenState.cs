using System;
using UnityEngine;
using UnityEngine.Events;

public class BrokenState : EnemyState
{
    [SerializeField] private float _fallDistance;
    
    public event UnityAction Died;

    public void ApplyDamage(Rigidbody attachedBody, float force)
    {
        Animator.SetTrigger("fall");
        Vector3 direction = (transform.position - attachedBody.position);
        direction.y = 0f;
        Rigidbody.AddForce(direction.normalized * force, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        var ray = new Ray(transform.position + Vector3.up, Vector3.down);
        if (Physics.Raycast(ray, _fallDistance) == false)
        {
            Rigidbody.constraints = RigidbodyConstraints.None;
            Died?.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (enabled == false) return;

        if (other.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage(Rigidbody, Rigidbody.velocity.magnitude);
        }
    }
}
