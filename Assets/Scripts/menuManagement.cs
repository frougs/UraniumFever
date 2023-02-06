using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManagement : MonoBehaviour
{
    private playerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startPress(){
        SceneManager.LoadScene(2);
    }

    public void quitPress(){
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void optionPress(){
        SceneManager.LoadScene(1);
    }

    public void backPress(){
        SceneManager.LoadScene(0);
    }

    public void menuPress(){
        SceneManager.LoadScene(0);
    }

    public void quickPress(){
        SceneManager.LoadScene(2);
    }
}
