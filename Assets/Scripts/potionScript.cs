using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionScript : MonoBehaviour
{
    private playerController playerController;
    public int scoreValue = 100;

    public Transform parentObject;

    public GameObject textPrefab;

    public GameObject invFull;
    void Awake(){
        playerController = GameObject.FindObjectOfType<playerController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            playerController player = playerController.GetComponent<playerController>();
            

            if(player.potionFull == false){
            Instantiate(textPrefab, new Vector2(parentObject.position.x, parentObject.position.y + 1), Quaternion.identity);
            player.playerInventory("Potion");
            player.Score(scoreValue);
            Destroy(gameObject);
            }

            if(player.potionFull == true){
                Instantiate(invFull, new Vector2(parentObject.position.x, parentObject.position.y + 1), Quaternion.identity);
            }

            
        }
    }
}
