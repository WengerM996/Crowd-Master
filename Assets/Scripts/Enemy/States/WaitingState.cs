using System;
using UnityEngine;

public class WaitingState : EnemyState
{
    private void OnEnable()
    {
        Animator.SetTrigger("setup");
    }

    private void Update()
    {
        
    }
}
