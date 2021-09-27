using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRotate : MonoBehaviour
{
    public GameObject bullet;

    private Vector3 offset = new Vector3(0, 0.7f, 0);
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
           transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        }
          if(Input.GetKeyDown(KeyCode.A))
        {
           transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        }
          if(Input.GetKeyDown(KeyCode.RightArrow))
        {
           transform.rotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
        }
          if(Input.GetKeyDown(KeyCode.D))
        {
           transform.rotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
        }
          if(Input.GetKeyDown(KeyCode.DownArrow))
        {
           transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
        }
         if(Input.GetKeyDown(KeyCode.S))
        {
           transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
        }
         if(Input.GetKeyDown(KeyCode.UpArrow))
        {
           transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
         if(Input.GetKeyDown(KeyCode.W))
        {
           transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position + offset, player.transform.rotation);
        }


    }
}
