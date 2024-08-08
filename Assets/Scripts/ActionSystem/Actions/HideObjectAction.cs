using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : ActionBase
{
    [SerializeField] private Vector3 _hidePosition;
    [SerializeField] private AudioSource _audioSource;
    
    public override void Execute(object data = null)
    {
        gameObject.transform.position = _hidePosition;
        _audioSource.Stop(); 
    }
}