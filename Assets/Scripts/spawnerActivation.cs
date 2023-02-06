using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerActivation : MonoBehaviour
{

    public int active = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

//Detects when player enters spawning radius
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
        active = 1;
        }
    }
//Detects when player leaves spawning radius
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            active = 0;
        }
    }
//Detects that the player stays in spawning
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
        active = 1;
        }
    }
}
