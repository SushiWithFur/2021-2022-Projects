using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public string pickupName;
    public int amount;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("player"))
        {
            print("You Got A " + pickupName + ". You are filled with rage towards locked doors.");
            gameManager.hasKey = true;
            Destroy(gameObject);
            
        }        
    }
}
