using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float hInput;
    public float vInput;
    public float playerSpeed;
    public Vector2 jumpHeight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * playerSpeed * Time.deltaTime * hInput);

    if (Input.GetKeyDown(KeyCode.Space))  //makes player jump
    {
        GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
    }
    }
}
