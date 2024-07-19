using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationClipByNameAction : ActionBase
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _name;

    public override void Execute(object data = null)
    {
        _animator.Play(_name);
    }
}
