using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //movement
    public float moveSpeed;
    public float jumpForce;
    //camera
    public float lookSensitivity; //mouse look sensitivity
    public float maxLookX; // lowest down position we can look
    public float minLookX; // highest up position we can look
    private float rotX; //current X rotation of the camera
    //game objects and components
    private Camera cam;
    private Rigidbody rb;
    private Weapon weapon;
    public bool isOnGround;

    void Awake() 
    {
        //Get the components
        cam = Camera.main;   
        rb = GetComponent<Rigidbody>();
        weapon = GetComponent<Weapon>();
        //disable cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();
        if(Input.GetButtonDown("Jump"))
         Jump();
        if(Input.GetButton("Fire1"))
        {
            if(weapon.CanShoot())
            {
                weapon.Shoot();
            }
        }
    }
    void Move()
    {
        if(Input.GetKey("left shift"))
        {
            moveSpeed = 10f;
        }
        else
        {
            if(isOnGround = true)
            {
                moveSpeed = 5f;
            }
        }
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        //face the direction of the camera
        Vector3 dir = transform.right * x + transform.forward * z;
        //jump direction
        dir.y = rb.velocity.y;
        //move in the direction of the camera
        rb.velocity = dir;

    }
    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(ray, 1.1f))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX  += Input.GetAxis("Mouse Y") * lookSensitivity;
        // clamps camera up and down rotation
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        // apply rotation to camera
        cam.transform.localRotation = Quaternion.Euler(-rotX,0,0);
        transform.eulerAngles += Vector3.up * y;
    }
    void onCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("isOnGround"))
        {
            isOnGround = true;
        }
    }
    private void OnCollisionExit(Collision other) 
    {
        isOnGround = false;
    }
}
