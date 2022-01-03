
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public void SceneSwitch(string name)
    {
        SceneManager.LoadScene("SampleScene copy");
    }

    public void Quit() 
    {
        Application.Quit();
    }
    // Start is called before the first frame update
}