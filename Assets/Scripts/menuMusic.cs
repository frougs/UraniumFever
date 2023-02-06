using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuMusic : MonoBehaviour
{
    private void Awake() {
        GameObject[] musicPlayer = GameObject.FindGameObjectsWithTag("Music");
        if(musicPlayer.Length > 1){
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        
    }

    private void Update() {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SampleScene")){
            Destroy(this.gameObject);
        }
    }
}
