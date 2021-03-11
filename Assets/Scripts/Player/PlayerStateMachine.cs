using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(Animator), typeof(HealthContainer))]
public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] private PlayerState _firstState;

    private PlayerState _currentState;
    private Rigidbody _rigidBody;
    private Animator _animator;
    private HealthContainer _health;

    public event UnityAction Damaged;

    private void OnEnable()
    {
        _health.Died += OnDied;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
    }

    private void OnDied()
    {
        enabled = false;
        _animator.SetTrigger("broken");
    }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _health = GetComponent<HealthContainer>();
    }

    private void Start()
    {
        _currentState = _firstState;
        _currentState.Enter(_rigidBody, _animator);
    }

    private void Update()
    {
        if (_currentState == null) return;

        var nextState = _currentState.GetNextState();
        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    private void Transit(PlayerState nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = nextState;

        if (_currentState != null)
        {
            _currentState.Enter(_rigidBody, _animator);
        }
    }

    public void ApplyDamage(float damage)
    {
        Damaged?.Invoke();
        _health.TakeDamage( (int) damage );
    }
}
