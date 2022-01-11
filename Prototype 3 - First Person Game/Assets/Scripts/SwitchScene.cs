
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public AudioSource click;
    public void SceneSwitch(string name)
    {
        click.Play();
        SceneManager.LoadScene("SampleScene copy");
    }

    public void Quit() 
    {
        click.Play();
        Application.Quit();
    }
    // Start is called before the first frame update
}