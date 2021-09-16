using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRotate : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float hInput;
    public float vInput;

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime * hInput);
        transform.Translate(Vector3.forward * speed * Time.deltaTime *vInput);
        
    }
}
