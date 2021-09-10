using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMatch : MonoBehaviour
{
    public GameObject tank;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = tank.transform.position;
        transform.rotation = tank.transform.rotation;
    
    }
}
