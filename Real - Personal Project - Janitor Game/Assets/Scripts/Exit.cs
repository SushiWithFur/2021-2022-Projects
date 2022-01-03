using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
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
            SceneManager.LoadScene("Exit");
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
