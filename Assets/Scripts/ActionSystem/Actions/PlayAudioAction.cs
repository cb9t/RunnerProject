using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioAction : ActionBase
{
    [SerializeField] private AudioSource _audioSource;

    public override void Execute(object data = null)
    {
        _audioSource.Play();
    }
}
