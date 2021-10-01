using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float hInput;
    public float vInput;

    public float xRange = 10.53f;
    public float yRange = 5.00f;

    

    // Update is called once per frame
    void Update()
    {
        //gathering keyboard input for movement
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        // Makes Player rotate left and right
        transform.Translate(Vector3.right * speed * Time.deltaTime * hInput);
        // Makes Player move forward and back
        transform.Translate(Vector3.up * speed * Time.deltaTime *vInput);

        //keeps player in bounds
        
        //right wall
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        //left wall
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        //top wall
        if(transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }
        //bottom wall
        if(transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
        



    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Kill"))
        {
            print("You were killed by an Enemy!! Lol, what a noob. git gud kid");
            Destroy(gameObject);  
        }
    }
}
