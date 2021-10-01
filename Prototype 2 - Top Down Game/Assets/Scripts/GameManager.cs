using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool hasKey;
    public bool isDoorLocked;
    // Start is called before the first frame update
    void Start()
    {
        hasKey = false;
        isDoorLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasKey && !isDoorLocked)
        {
            print("You exit out of the door into another room! It's Filled with many frogs. How could this be?");
        }
    }
}
