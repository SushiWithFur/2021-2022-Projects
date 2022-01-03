using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public GameObject Player;
    public Transform target;
    public GameObject cam;
    public Transform camPos;

    public bool hasKey;
    
    // Start is called before the first frame update
    void Start()
    {
        hasKey = false;
        
    }

    void OnTriggerStay2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player" && hasKey)
        {
            Player.transform.position = target.transform.position;
            cam.transform.position = camPos.transform.position;
            hasKey = false;
        }
    }

    public void Unlock()
    {
        hasKey = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
