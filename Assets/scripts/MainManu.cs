using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour
{

    public void onExit()
    {
        Application.Quit();
    }
    public void onStart()
    {
        SceneManager.LoadScene(0);
    }
}
