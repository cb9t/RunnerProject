using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PouseAgentMovement : ActionBase
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _pouseTime;

    public override void Execute(object data = null)
    {
        StartCoroutine(StopAgentOnTime());
    }
    private IEnumerator StopAgentOnTime()
    {
        _agent.isStopped = true;
        yield return new WaitForSeconds(_pouseTime);
        _agent.isStopped = false;
    }
}
