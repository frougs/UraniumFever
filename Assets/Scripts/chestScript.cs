using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestScript : MonoBehaviour
{

    public int scoreValue = 100;

    private playerController playerController;

    public Transform parentObject;

    

    public GameObject textPrefab;
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

    private void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.tag == "Player"){
            playerController player = playerController.GetComponent<playerController>();
            player.Score(scoreValue);
            player.Sounds("Item");
            Destroy(gameObject);

            Instantiate(textPrefab, new Vector2(parentObject.position.x, parentObject.position.y + 1), Quaternion.identity);
        }
    }

}
