using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//code from https://www.youtube.com/watch?v=PpIkrff7bKU

public class SceneSwitch : MonoBehaviour
{
    public void loaderLvl1()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void loaderLvl2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void loaderMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
