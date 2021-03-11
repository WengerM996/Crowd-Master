using System;
using UnityEngine;
using UnityEngine.Events;

public class AttackState : PlayerState
{
    [SerializeField] private StaminaAccumulator _staminaAccumulator;
    
    private Ability _currentAbility;

    public event UnityAction<IDamageable> CollisionDetected;
    public event UnityAction AbilityEnded;

    private void OnEnable()
    {
        Animator.SetTrigger("attack");
        _currentAbility = _staminaAccumulator.GetAbility();
        _currentAbility.AttackEnded += OnAttackEnded;
        
        _currentAbility.UseAbility(this);
    }

    private void OnDisable()
    {
        _currentAbility.AttackEnded -= OnAttackEnded;
    }

    private void OnAttackEnded()
    {
        AbilityEnded?.Invoke();
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            CollisionDetected?.Invoke(damageable);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            CollisionDetected?.Invoke(damageable);
        }
    }
}
