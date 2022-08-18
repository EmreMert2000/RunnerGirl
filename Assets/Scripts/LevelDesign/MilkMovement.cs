using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkMovement : MonoBehaviour
{
    public Transform connectModle, connectedModle;
    public float spacelayer = 1;
    public GameObject milobject;
     void Update()
    {
       
            transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, connectModle.position.x, Time.deltaTime * 20),
            connectModle.position.y,
            connectModle.position.z + spacelayer);
        
        
    }
}
