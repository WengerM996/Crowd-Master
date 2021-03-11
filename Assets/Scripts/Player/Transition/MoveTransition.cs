using System;
using UnityEngine;

public class MoveTransition : PlayerTransition
{
    public override void Enable()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            NeedTransit = true;
        }
    }
}
