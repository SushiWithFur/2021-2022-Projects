using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    public Transform playerStart;
    public Transform camStart;
    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = playerStart.transform.position;
        cam.transform.position = camStart.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
