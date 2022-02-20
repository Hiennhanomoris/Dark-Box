using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offsetVector;

    private void Start() 
    {
        offsetVector = PlayerStatus.Instance.transform.position - this.transform.position;    
    }

    private void FixedUpdate() 
    {
        this.transform.position = PlayerStatus.Instance.transform.position - offsetVector;    
    }
}
