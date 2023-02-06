using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fullScript : MonoBehaviour
{

    private playerController playerController;

    void Awake() {
    playerController = GameObject.FindObjectOfType<playerController>();
    Destroy(gameObject, 0.5f); 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerController player = playerController.GetComponent<playerController>();
        player.Sounds("Full");
    }
}
