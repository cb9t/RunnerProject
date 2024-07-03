using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTeleport : MonoBehaviour
{
    [SerializeField] float _startPosition;
    [SerializeField] float _endPosition;
    void Update()
    {
        if (transform.position.z < _endPosition) { transform.position = new Vector3(transform.position.x, transform.position.y, _startPosition); }
    }
}
