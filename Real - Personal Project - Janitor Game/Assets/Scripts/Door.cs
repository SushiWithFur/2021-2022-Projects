using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject Player;
    public Transform target;
    public GameObject cam;
    public Transform camPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            Player.transform.position = target.transform.position;
            cam.transform.position = camPos.transform.position;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
