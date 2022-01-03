using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void SwitchScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Quit() 
    {
        Application.Quit();
    }
    // Start is called before the first frame update
}
