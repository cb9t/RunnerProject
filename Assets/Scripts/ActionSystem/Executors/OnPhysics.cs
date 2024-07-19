using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPhysics : ExecutorBase
{
    public enum State {Enter, Exit, Stay}

    [SerializeField] private bool _onTrigger;
    [SerializeField] private bool _onCollision;
    [SerializeField] private State _state;

    private void OnTriggerEnter(Collider other)
    {
        if (_onTrigger && _state == State.Enter)
            {
            Execute(other);
            }
    }
    private void OnTriggerExit(Collider other) 
    {
        if (_onTrigger && _state == State.Exit)
        {
            Execute(other);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (_onTrigger && _state == State.Stay) 
        {
        Execute(other);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(_onCollision && _state == State.Enter)
        { 
            Execute(collision);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (_onCollision && _state == State.Exit)
        {
            Execute(collision);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (_onCollision && _state == State.Stay)
        {
            Execute(collision);
        }
    }
}
