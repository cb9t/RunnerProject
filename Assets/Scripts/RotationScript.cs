using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public enum AxisRotation {x,y,z};
    [SerializeField] private AxisRotation _axisRotation;
    private Vector3 _rotation;

    private void Awake()
    {
         switch (_axisRotation)
        {
            case AxisRotation.x:
                _rotation = new Vector3(50, 0, 0);
                break;
            case AxisRotation.y:
                _rotation = new Vector3(0, 50, 0);
                break;
            case AxisRotation.z:
                _rotation = new Vector3(0, 0, 50);
                break;
        }
    }
    private void FixedUpdate()
    {
        gameObject.transform.Rotate(_rotation);
    }
}
