using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScript : MonoBehaviour
{
    private void Start()
    {
        Invoke("GotoGameScene",2.0f);
        
    }
    public void GotoGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
