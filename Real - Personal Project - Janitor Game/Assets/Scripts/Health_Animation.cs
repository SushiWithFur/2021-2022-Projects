using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Animation : MonoBehaviour
{
    public GameObject healthFull;
    public GameObject health2;
    public GameObject health1;
    // Start is called before the first frame update

    public void ChangeHealth(int health)
    {
        switch (health)
        {
            case 3:
                healthFull.SetActive(true);
                health1.SetActive(false);
                health2.SetActive(false);
                break;
            case 2:
                healthFull.SetActive(false);
                health1.SetActive(false);
                health2.SetActive(true);
                break;
            case 1:
                healthFull.SetActive(false);
                health1.SetActive(true);
                health2.SetActive(false);
                break;
            default:
                healthFull.SetActive(true);
                health1.SetActive(false);
                health2.SetActive(false);
                break;
        }
    }
}
